using ScientificPublications.Application.Common.Models.Scopus;
using ScientificPublications.Infrastructure.Converters;

namespace ScientificPublications.Infrastructure.Scopus.Converters
{
    public class AuthorConverter : NameValueConverter<Author>
    {
        public AuthorConverter()
        {
            AddMap(n => n.Name, "ce:indexed-name");
            AddMap(n => n.ScopusId, "@auid");
        }
    }
}
