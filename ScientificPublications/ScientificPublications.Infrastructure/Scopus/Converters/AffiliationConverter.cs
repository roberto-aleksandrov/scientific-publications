using ScientificPublications.Application.Common.Models.Dtos;
using ScientificPublications.Infrastructure.Converters;

namespace ScientificPublications.Infrastructure.Scopus.Converters
{
    internal class AffiliationConverter : NameValueConverter<ScopusAffiliationDto>
    {
        public AffiliationConverter()
        {
            CreateaMappings(builder =>
            {
                builder
                    .AddMap(n => n.ScopusId, "@id")
                    .AddMap(n => n.City, "affiliation-city")
                    .AddMap(n => n.Country, "affiliation-country")
                    .AddMap(n => n.Name, "affilname")
                    .AddMap(n => n.ScopusUrl, "@href");
            });
        }
    }
}