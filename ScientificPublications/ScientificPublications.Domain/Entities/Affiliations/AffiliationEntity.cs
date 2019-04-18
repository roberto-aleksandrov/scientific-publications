using ScientificPublications.Domain.Entities.PublicationAffiliations;
using ScientificPublications.Domain.Entities.Publications;
using System.Collections.Generic;

namespace ScientificPublications.Domain.Entities.Affiliations
{
    public class AffiliationEntity : BaseEntity
    {
        public AffiliationEntity()
        {
            PublicationAffiliations = new List<PublicationAffiliationEntity>();
        }

        public int Id { get; set; }

        public string ScopusId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string ScopusUrl { get; set; }

        public List<PublicationAffiliationEntity> PublicationAffiliations { get; set; }
    }
}
