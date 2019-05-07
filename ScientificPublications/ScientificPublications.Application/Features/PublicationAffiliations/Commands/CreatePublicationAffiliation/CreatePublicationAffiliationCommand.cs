using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Domain.Entities.PublicationAffiliations;

namespace ScientificPublications.Application.Features.PublicationAffiliations.Commands.CreatePublicationAffiliation
{
    public class CreatePublicationAffiliationCommand : BaseCommand<PublicationAffiliationEntity>
    {
        public int AffiliationId { get; set; }

        public int PublicationId { get; set; }
    }
}
