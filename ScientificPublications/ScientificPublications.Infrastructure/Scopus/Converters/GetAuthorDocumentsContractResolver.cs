using ScientificPublications.Application.Common.Models.Responses;
using ScientificPublications.Infrastructure.Converters;

namespace ScientificPublications.Infrastructure.Scopus.Converters
{
    public class GetAuthorDocumentsContractResolver : NameValueConverter<GetAuthorDocumentsResponse>
    {
        public GetAuthorDocumentsContractResolver()
        {
            AddMap(n => n.Documents, "search-results.entry", new DocumentConverter());
        }
    }
}
