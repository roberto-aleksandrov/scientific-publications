using ScientificPublications.Application.Common.Models.Scopus;
using ScientificPublications.Infrastructure.ContractResolvers;
using ScientificPublications.Infrastructure.Converters;
using ScientificPublications.Infrastructure.Scopus.Converters;

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
