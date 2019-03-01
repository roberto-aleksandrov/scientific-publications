using System.Collections.Generic;

namespace ScientificPublications.Application.Common.Models.Scopus
{
    public class GetAuthorPublicationsResponse
    {
        public ICollection<AuthorPublication> AuthorPublications { get; set; }
    }
}
