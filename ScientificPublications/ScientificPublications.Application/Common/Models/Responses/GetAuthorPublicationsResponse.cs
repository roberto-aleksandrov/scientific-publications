using ScientificPublications.Application.Common.Models.Dtos;
using System.Collections.Generic;

namespace ScientificPublications.Application.Common.Models.Responses
{
    public class GetAuthorPublicationsResponse
    {
        public ICollection<ScopusAuthorPublicationDto> AuthorPublications { get; set; }
    }
}
