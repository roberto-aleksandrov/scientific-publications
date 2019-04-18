using ScientificPublications.Application.Common.Models.Dtos;
using System;
using System.Collections.Generic;

namespace ScientificPublications.WebUI.Models.BindingModels.Publications
{
    public class CreatePublicationBindingModel : BindingModel
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

        public ICollection<int> AffiliationIds { get; set; }

        public ICollection<int> AuthorIds { get; set; }
    }
}
