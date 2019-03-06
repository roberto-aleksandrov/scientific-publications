using ScientificPublications.Application.Common.Models.Dtos;
using ScientificPublications.Infrastructure.Converters;

namespace ScientificPublications.Infrastructure.Scopus.Converters
{
    public class DocumentConverter : NameValueConverter<ScopusDocumentDto>
    {
        public DocumentConverter()
        {
            AddMap(n => n.DocumentScopusId, "dc:identifier", n => n.Replace("SCOPUS_ID:", ""));
            AddMap(n => n.Url, "prism:url");
        }
    }
}
