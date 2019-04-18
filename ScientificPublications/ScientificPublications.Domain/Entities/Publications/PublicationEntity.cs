using ScientificPublications.Domain.Entities.Affiliations;
using ScientificPublications.Domain.Entities.AuthorsPublications;
using ScientificPublications.Domain.Entities.PublicationAffiliations;
using System;
using System.Collections.Generic;

namespace ScientificPublications.Domain.Entities.Publications
{
    public class PublicationEntity : BaseEntity
    {
        public PublicationEntity()
        {
            AuthorsPublications = new List<AuthorPublicationEntity>();
            PublicationAffiliations = new List<PublicationAffiliationEntity>();
        }

        public int Id { get; set; }
        
        public string ScopusId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Isbn { get; set; }

        public string Doi { get; set; }

        public string Issn { get; set; }

        public string Type { get; set; }

        public string ScopusUrl { get; set; }

        public string StartingPage { get; set; }

        public string EndingPage { get; set; }
        
        public string Publisher { get; set; }

        public ICollection<AuthorPublicationEntity> AuthorsPublications { get; set; }

        public ICollection<PublicationAffiliationEntity> PublicationAffiliations { get; set; }
    }
}
