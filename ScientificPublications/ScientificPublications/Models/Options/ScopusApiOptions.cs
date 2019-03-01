using ScientificPublications.Infrastructure.Scopus.Options;

namespace ScientificPublications.WebUI.Models.Options
{
    public class ScopusApiOptions : IScopusApiOptions
    {
        public string ApiKey { get; set; }

        public string Url { get; set; }
    }
}
