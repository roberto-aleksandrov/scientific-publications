using Newtonsoft.Json.Linq;
using ScientificPublications.Application.Common.Models.Dtos;
using ScientificPublications.Infrastructure.Converters;
using System.Linq;

namespace ScientificPublications.Infrastructure.Scopus.Converters
{
    public class AuthorPublicationConverter : NameValueConverter<ScopusPublicationDto>
    {
        public AuthorPublicationConverter()
        {
            CreateaMappings(builder =>
            {
                builder
                .WithBasePath("abstracts-retrieval-response.item.bibrecord.head")
                .AddMap(n => n.Title, "citation-title")
                .AddMap(n => n.Description, "abstracts")
                .AddMap(n => n.Authors, "author-group.author", new AuthorConverter());

                builder
                    .WithBasePath("abstracts-retrieval-response")
                    .AddMap(n => n.Affiliations, "affiliation", new AffiliationConverter());

                builder
                    .WithBasePath("abstracts-retrieval-response.coredata")
                    .AddMap(n => n.PublicationDate, "prism:coverDate")
                    .AddMap(n => n.Doi, "prism:doi")
                    .AddMap(n => n.Issn, "prism:issn")
                    .AddMap(n => n.StartingPage, "prism:startingPage")
                    .AddMap(n => n.EndingPage, "prism:endingPage")
                    .AddMap(n => n.Publisher, "dc:publisher")
                    .AddMap(n => n.ScopusUrl, "prism:url")
                    .AddMap(n => n.ScopusId, "dc:identifier", n => n.Replace("SCOPUS_ID:", ""))
                    .AddMap(n => n.Type, "prism:aggregationType")
                    .AddMap(n => n.Isbn, cfgBuilder => cfgBuilder
                            .WithPath("prism:isbn")
                            .BeforeMap(n =>
                            {
                                if (n is JArray jarr)
                                {
                                    return string.Join(",", jarr.Select(jt => jt["$"]));
                                }

                                return n;
                            }));
            });
        }
    }
}
