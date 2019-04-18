using ScientificPublications.Domain.Entities.Affiliations;
using ScientificPublications.Domain.Entities.Publications;

namespace ScientificPublications.Domain.Entities.PublicationAffiliations
{
    public class PublicationAffiliationEntity : BaseEntity
    {
        public int PublicationId { get; set; }

        public PublicationEntity Publication { get; set; }

        public int AffiliationId { get; set; }

        public AffiliationEntity Affiliation { get; set; }
    }
}
