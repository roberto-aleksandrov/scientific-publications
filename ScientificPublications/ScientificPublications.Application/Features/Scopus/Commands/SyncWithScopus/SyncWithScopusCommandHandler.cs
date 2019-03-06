using AutoMapper;
using Extensions;
using MediatR;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Interfaces.Scopus;
using ScientificPublications.Application.Common.Models.Dtos;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Common.Models.Requests;
using ScientificPublications.Application.Features.Authors.Specifications;
using ScientificPublications.Application.Features.Publications.Commands.CreatePublication;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Scopus.Commands.SyncWithScopus
{
    public class SyncWithScopusCommandHandler : BaseRequestHandler<SyncWithScopusCommand, IEnumerable<PublicationEntity>>
    {
        private readonly IMediator _mediator;
        private readonly IScopusApi _scopusApi;

        public SyncWithScopusCommandHandler(IData data, IMapper mapper, IMediator mediator, IScopusApi scopusApi)
            : base(data, mapper)
        {
            _mediator = mediator;
            _scopusApi = scopusApi;
        }

        private Func<ScopusAuthorPublicationDto, Task<PublicationEntity>> CreatePublication(UserInfo userInfo, IReadOnlyList<AuthorEntity> authors)
        {
            async Task<PublicationEntity> func(ScopusAuthorPublicationDto publication)
            {
                var createPublicationCommand = _mapper.Map<CreatePublicationCommand>(publication);

                createPublicationCommand.AuthorIds = GetAuthorIdsForPublication(publication, authors);
                createPublicationCommand.UserInfo = userInfo;

                return await _mediator.Send(createPublicationCommand);
            }

            return func;
        }

        private async Task<IEnumerable<ScopusAuthorPublicationDto>> GetNewScopusPublicationsByAuthorAsync(AuthorEntity author)
        {
            var getAuthorPublicationsRequest = new GetAuthorPublicationsRequest { AuthorScopusId = author.ScopusId };

            var response = await _scopusApi.GetAuthorPublications(getAuthorPublicationsRequest);

            return response.AuthorPublications
                .Where(p => author.AuthorsPublications
                    .All(ap => ap.Publication.ScopusId != p.ScopusId));
        }

        private ICollection<int> GetAuthorIdsForPublication(ScopusAuthorPublicationDto publication, IReadOnlyList<AuthorEntity> authors)
        {
            return authors
                .Where(a => publication.Authors
                    .Any(sa => sa.ScopusId == a.ScopusId))
                .Select(a => a.Id)
                .ToList();
        }

        public override async Task<IEnumerable<PublicationEntity>> Handle(SyncWithScopusCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<PublicationEntity> publicationEntities = null;
            var authors = await _data.Authors.ListAsync(new GetScopusAuthorsSpecification());

            await authors.ForEachAsync(async author =>
            {
                var publications = await GetNewScopusPublicationsByAuthorAsync(author);

                publicationEntities = await publications.SelectAsync(CreatePublication(request.UserInfo, authors));

            });

            return publicationEntities;
        }
    }
}

