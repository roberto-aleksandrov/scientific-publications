using ScientificPublications.Application.Common.Models.Scopus;
using ScientificPublications.Infrastructure.Converters;

namespace ScientificPublications.Infrastructure.Scopus.Converters
{
    public class DocumentConverter : NameValueConverter<Document>
    {
        public DocumentConverter()
        {
            AddMap(n => n.DocumentScopusId, "dc:identifier", n => n.Replace("SCOPUS_ID:", ""));
            AddMap(n => n.Url, "prism:url");
        }
    }
}
