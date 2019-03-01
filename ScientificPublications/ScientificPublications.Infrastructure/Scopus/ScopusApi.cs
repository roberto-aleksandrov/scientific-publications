﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScientificPublications.Application.Common.Interfaces.Scopus;
using ScientificPublications.Application.Common.Models.Scopus;
using ScientificPublications.Infrastructure.Scopus.Constants;
using ScientificPublications.Infrastructure.Scopus.Converters;
using ScientificPublications.Infrastructure.Scopus.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScientificPublications.Infrastructure.Scopus
{
    public class ScopusApi : IScopusApi
    {
        private readonly HttpClient _client;

        public ScopusApi(IScopusApiOptions scopusApiOptions)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add(ScopusHeaders.API_KEY, scopusApiOptions.ApiKey);
            _client.DefaultRequestHeaders.Add("accept", "application/json");
            _client.BaseAddress = new Uri(scopusApiOptions.Url);
        }

        public async Task<GetAuthorPublicationsResponse> GetAuthorPublications(GetAuthorPublicationsRequest getAuthorPublicationsRequest)
        {
            var authorDocuments = await GetAuthorDocuments(new GetAuthorDocumentsRequest { AuthorScopusId = getAuthorPublicationsRequest.AuthorScopusId });
            var authorPublications = new List<AuthorPublication>();
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new AuthorPublicationConverter());

            foreach (var document in authorDocuments.Documents)
            {
                var response = await _client.GetAsync(ScopusUrls.GetAbstracts(document.DocumentScopusId));
                var content = await response.Content.ReadAsStringAsync();
                var authorPublication = JObject.Parse(content).ToObject<AuthorPublication>(serializer);

                authorPublication.ScopusId = document.DocumentScopusId;

                authorPublications.Add(authorPublication);
            }

            return new GetAuthorPublicationsResponse { AuthorPublications = authorPublications };
        }

        public async Task<GetAuthorDocumentsResponse> GetAuthorDocuments(GetAuthorDocumentsRequest getAuthorDocumentsRequest)
        {
            var response = await _client.GetAsync(ScopusUrls.GetDocumentsUrl(getAuthorDocumentsRequest.AuthorScopusId));

            var content = await response.Content.ReadAsStringAsync();
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new GetAuthorDocumentsContractResolver());

            var documents = JObject.Parse(content).ToObject<GetAuthorDocumentsResponse>(serializer);

            return documents;
        }
    }
}
