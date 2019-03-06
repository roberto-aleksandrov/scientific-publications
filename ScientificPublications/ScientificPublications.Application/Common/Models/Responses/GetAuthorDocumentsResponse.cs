using ScientificPublications.Application.Common.Models.Dtos;
using System.Collections.Generic;

namespace ScientificPublications.Application.Common.Models.Responses
{
    public class GetAuthorDocumentsResponse
    {
        public List<ScopusDocumentDto> Documents { get; set; }
    }
}
