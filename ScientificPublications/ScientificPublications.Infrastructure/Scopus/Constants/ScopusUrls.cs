using System;

namespace ScientificPublications.Infrastructure.Scopus.Constants
{
    internal static class ScopusUrls
    {
        public static Func<string, string> GetDocumentsUrl = (scopusId) => $"content/search/scopus?query=AU-ID({scopusId})&field=dc:identifier";

        public static Func<string, string> GetAbstracts = (scopusId) => $"content/abstract/scopus_id/${scopusId}";
    }
}
