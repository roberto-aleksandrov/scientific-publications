using AutoMapper;
using Extensions;
using MediatR;
using ScientificPublications.Application.Common.Constants.Validators;
using ScientificPublications.Application.Common.Exceptions;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Interfaces.Scopus;
using ScientificPublications.Application.Common.Models.Dtos;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Common.Models.Requests;
using ScientificPublications.Application.Features.Affiliations.Commands.CreateAffiliation;
using ScientificPublications.Application.Features.Affiliations.Specifications;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Application.Features.Authors.Specifications;
using ScientificPublications.Application.Features.Publications.Commands.CreatePublication;
using ScientificPublications.Domain.Entities.Affiliations;
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

        private async Task<IEnumerable<AuthorEntity>> CreateMissingAuthors(IEnumerable<AuthorEntity> existingAuthors, ScopusPublicationDto scopusPublication)
        {
            return await scopusPublication.Authors
                            .Where(pa => existingAuthors.All(a => a.ScopusId != pa.ScopusId))
                            .SelectAsync(a => _mediator.Send(_mapper.Map<CreateAuthorCommand>(a)));
        }
        
        private Func<ScopusPublicationDto, Task<PublicationEntity>> CreatePublication(UserInfo userInfo, IEnumerable<AuthorEntity> authors)
        {
            var authorsList = authors.ToList();

            async Task<PublicationEntity> func(ScopusPublicationDto publication)
            {
                var newAuthors = await CreateMissingAuthors(authorsList, publication);
                var affiliations = await CreateAffiliation(publication.Affiliations);
                authorsList.AddRange(newAuthors);

                var createPublicationCommand = _mapper.Map<CreatePublicationCommand>(publication);

                createPublicationCommand.AuthorIds = authorsList.Select(n => n.Id).ToList();
                createPublicationCommand.AffiliationIds = affiliations?.Select(n => n.Id)?.ToList();
                createPublicationCommand.UserInfo = userInfo;

                return await _mediator.Send(createPublicationCommand);
            }

            return func;
        }

        private async Task<IEnumerable<AffiliationEntity>> CreateAffiliation(IEnumerable<ScopusAffiliationDto> affiliationDtos)
        {
            if(affiliationDtos == null)
            {
                return null;
            }

            return await affiliationDtos?.SelectAsync(async affiliationDto =>
            {
                AffiliationEntity affiliationEntity = null;

                try
                {
                    var createAffiliationCommand = _mapper.Map<CreateAffiliationCommand>(affiliationDto);

                    affiliationEntity = await _mediator.Send(createAffiliationCommand);
                }
                catch (ValidationException e)
                    when (e.ErrorType == ErrorTypes.InvalidData)
                {
                    var getAffiliationSpec = new GetScopusAffiliationsSpecification(affiliationDto.ScopusId) { IncludeUncommited = true} ;

                    affiliationEntity = await _data.Affiliations.SingleAsync(getAffiliationSpec);
                }

                return affiliationEntity;
            });
        }

        private async Task<IEnumerable<ScopusPublicationDto>> GetNewScopusPublicationsByAuthorAsync(AuthorEntity author)
        {
            var getAuthorPublicationsRequest = new GetAuthorPublicationsRequest { AuthorScopusId = author.ScopusId };

            var response = await _scopusApi.GetAuthorPublications(getAuthorPublicationsRequest);

            return response.AuthorPublications
                .Where(p => author.AuthorsPublications
                    .All(ap => ap.Publication.ScopusId != p.ScopusId));
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

