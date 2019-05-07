using AutoMapper;
using Extensions;
using MediatR;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Features.AuthorPublications.Commands.CreateAuthorPublication;
using ScientificPublications.Application.Features.PublicationAffiliations.Commands.CreatePublicationAffiliation;
using ScientificPublications.Domain.Entities.Publications;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Publications.Commands.CreatePublication
{
    public class CreatePublicationCommandHandler : BaseRequestHandler<CreatePublicationCommand, PublicationEntity>
    {
        private readonly IMediator _mediator;

        public CreatePublicationCommandHandler(IData data, IMapper mapper, IMediator mediator)
            : base(data, mapper)
        {
            _mediator = mediator;
        }

        public override async Task<PublicationEntity> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
        {
            var publicationEntity = _mapper.Map<PublicationEntity>(request);

            await _data.Publications.AddAsync(publicationEntity);

            await request.AuthorIds?.ForEachAsync(async n =>
            {
                await _mediator.Send(new CreateAuthorPublicationCommand
                {
                    PublicationId = publicationEntity.Id,
                    AuthorId = n,
                    UserInfo = request.UserInfo
                });
            });

            await request.AffiliationIds?.ForEachAsync(async n =>
            {
                await _mediator.Send(new CreatePublicationAffiliationCommand
                {
                    PublicationId = publicationEntity.Id,
                    AffiliationId = n,
                    UserInfo = request.UserInfo
                });
            });

            return publicationEntity;
        }
    }
}
