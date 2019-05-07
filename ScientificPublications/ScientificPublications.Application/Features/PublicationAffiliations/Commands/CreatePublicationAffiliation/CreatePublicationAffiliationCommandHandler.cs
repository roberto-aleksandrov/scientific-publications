using AutoMapper;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Features.Affiliations.Specifications;
using ScientificPublications.Application.Features.Publications.Specifications;
using ScientificPublications.Domain.Entities.PublicationAffiliations;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.PublicationAffiliations.Commands.CreatePublicationAffiliation
{
    public class CreatePublicationAffiliationCommandHandler : BaseRequestHandler<CreatePublicationAffiliationCommand, PublicationAffiliationEntity>
    {
        public CreatePublicationAffiliationCommandHandler(IData data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public override async Task<PublicationAffiliationEntity> Handle(CreatePublicationAffiliationCommand request, CancellationToken cancellationToken)
        {
            var affiliation = await _data.Affiliations.SingleAsync(new GetAffiliationSpecification(request.AffiliationId) { IncludeUncommited = true });

            var publication = await _data.Publications.SingleAsync(new GetPublicationSpecification(request.PublicationId) { IncludeUncommited = true });

            var publicationAffiliation = new PublicationAffiliationEntity
            {
                Affiliation = affiliation,
                Publication = publication
            };

            publicationAffiliation = await _data.PublicationAffiliations.AddAsync(publicationAffiliation);

            return publicationAffiliation;
        }
    }
}
