using System;
using System.Collections.Generic;

namespace ScientificPublications.Application.Common.Models.Dtos
{
    public class ScopusPublicationDto
    {
        public string ScopusId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? PublicationDate { get; set; }

        public string Isbn { get; set; }

        public string Doi { get; set; }

        public string Issn { get; set; }

        public string Type { get; set; }

        public string ScopusUrl { get; set; }

        public string StartingPage { get; set; }

        public string EndingPage { get; set; }

        public string Publisher { get; set; }

        public List<ScopusAffiliationDto> Affiliations { get; set; }

        public List<ScopusAuthorDto> Authors { get; set; }
    }
}
