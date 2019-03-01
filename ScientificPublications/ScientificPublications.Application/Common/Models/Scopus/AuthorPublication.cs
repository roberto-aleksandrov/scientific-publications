using Newtonsoft.Json;
using System.Collections.Generic;

namespace ScientificPublications.Application.Common.Models.Scopus
{
    public class AuthorPublication
    {
        public string Title { get; set; }

        public string Text { get; set; }

        [JsonIgnore]
        public string ScopusId { get; set; }

        public List<Author> Authors { get; set; }
    }
}
