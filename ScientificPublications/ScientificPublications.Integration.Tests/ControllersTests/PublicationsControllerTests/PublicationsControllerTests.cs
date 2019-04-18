﻿using Microsoft.EntityFrameworkCore;
using ScientificPublications.Application.Common.Constants.Validators;
using ScientificPublications.Domain.Entities.AuthorsPublications;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Integration.Tests.ControllersTests.PublicationsControllerTests.Contracts;
using ScientificPublications.Integration.Tests.Fakers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ScientificPublications.Integration.Tests.ControllersTests.PublicationsControllerTests
{
    public class PublicationsControllerTests : ControllerTests
    {
        [Fact]
        public async Task CreatePublication_Test()
        {
            var authors = _factory.Seeder.SeedMany<AuthorEntity>(10);
            var request = RequestsFaker.CreatePublicationFaker.Generate();
            request.AuthorIds = authors.Select(n => n.Id).ToList();

            await Authenticate();
            var response = await PostAsync<CreatePublicationRequest, List<int>>(request);

            var publication = _factory.Context.Publications
                .Include(n => n.AuthorsPublications)
                .First(n => n.Id == response.Content.First());

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(request.Description, publication.Description);
            Assert.Equal(request.Doi, publication.Doi);
            Assert.Equal(request.Title, publication.Title);
            Assert.Equal(string.Join("", request.AuthorIds), string.Join("", publication.AuthorsPublications.Select(n => n.AuthorId)));
        }

        [Fact]
        public async Task CreatePublication_NonUniqueAuthorIds_Test()
        {
            var request = RequestsFaker.CreatePublicationFaker.Generate();
            request.AuthorIds = new List<int>() { 1, 1, 1 };

            await Authenticate();
            var response = await PostAsync<CreatePublicationRequest, List<int>>(request);
            var errorMessage = response.ErrorMessages.FirstOrDefault();

            Assert.Equal(nameof(request.AuthorIds), errorMessage.Key);
            Assert.Equal(ErrorMessages.NotUnique.Replace("{PropertyName}", ""), errorMessage.Value[0]);
        }

        [Fact]
        public async Task CreatePublication_AuthorDoesNotExist_Test()
        {
            var request = RequestsFaker.CreatePublicationFaker.Generate(); ;
            request.AuthorIds = new List<int>() { 1, 2, 100 };

            await Authenticate();
            var response = await PostAsync<CreatePublicationRequest, List<int>>(request);
            var errorMessage = response.ErrorMessages.FirstOrDefault();

            Assert.Equal(nameof(request.AuthorIds), errorMessage.Key);
            Assert.Equal(ErrorMessages.EntityExists, errorMessage.Value[0]);
        }

        [Fact]
        public async Task GetAllPublications_Test()
        {
            var authorPublications = _factory.Seeder.SeedMany<AuthorPublicationEntity>(10);
            var getAllPublicationsRequest = new GetAllPublicationsRequest() { QueryString = new { Include = nameof(PublicationEntity.AuthorsPublications) } };

            await Authenticate();
            var response = await GetAsync<GetAllPublicationsRequest, IEnumerable<GetPublicationResponse>>(getAllPublicationsRequest);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(authorPublications.Count(), response.Content.Count());
        }
    }
}
