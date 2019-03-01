using ScientificPublications.Application.Common.Models.Scopus;
using ScientificPublications.Infrastructure.Converters;

namespace ScientificPublications.Infrastructure.Scopus.Converters
{
    public class AuthorPublicationConverter : NameValueConverter<AuthorPublication>
    {
        public AuthorPublicationConverter()
        {
            AddMap(n => n.Title, "abstracts-retrieval-response.item.bibrecord.head.citation-title");
            AddMap(n => n.Text, "abstracts-retrieval-response.item.bibrecord.head.abstracts");
            AddMap(n => n.Authors, "abstracts-retrieval-response.item.bibrecord.head.author-group.author", new AuthorConverter());
        }
    }
}
