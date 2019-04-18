using ScientificPublications.Application.Common.Models.Dtos;
using ScientificPublications.Infrastructure.Converters;

namespace ScientificPublications.Infrastructure.Scopus.Converters
{
    public class AuthorConverter : NameValueConverter<ScopusAuthorDto>
    {
        public AuthorConverter()
        {
            CreateaMappings(builder =>
            {
                builder
                    .AddMap(n => n.Name, "ce:indexed-name")
                    .AddMap(n => n.ScopusId, "@auid");
            });
        }
    }
}
