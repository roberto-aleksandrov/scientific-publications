using Microsoft.EntityFrameworkCore;
using ScientificPublications.Application.Common.Constants.Validators;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Integration.Tests.ControllersTests.PublicationsControllerTests.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ScientificPublications.Integration.Tests.ControllersTests.PublicationsControllerTests
{
    public class PublicationsControllerTests : ControllerTests
    {
        [Fact]
        public async Task CreatePublication_Test()
        {
            var request = TestData.CreatePublicationRequest;
            request.AuthorIds = _factory.Context.Authors.Select(n => n.Id).ToList();

            await Authenticate();
            var response = await PostAsync<CreatePublicationRequest, List<int>>(request);

            var publication = _factory.Context.Publications
                .Include(n => n.AuthorsPublications)
                .First(n => n.Id == response.First());

            Assert.Equal(request.Text, publication.Text);
            Assert.Equal(request.Title, publication.Title);
            Assert.Equal(string.Join("", request.AuthorIds), string.Join("", publication.AuthorsPublications.Select(n => n.AuthorId)));
        }

        [Fact]
        public async Task CreatePublication_NonUniqueAuthorIds_Test()
        {
            var request = TestData.CreatePublicationRequest;
            request.AuthorIds = new List<int>() { 1, 1, 1 };

            await Authenticate();
            var response = await PostAsync<CreatePublicationRequest, CreatePublicationResponse>(request);
            var errorMessage = _errorMessages.FirstOrDefault();

            Assert.Equal(nameof(request.AuthorIds), errorMessage.Key);
            Assert.Equal(ErrorMessages.NotUnique.Replace("{PropertyName}", ""), errorMessage.Value[0]);
        }

        [Fact]
        public async Task CreatePublication_AuthorDoesNotExist_Test()
        {
            var request = TestData.CreatePublicationRequest;
            request.AuthorIds = new List<int>() { 1, 2, 100 };

            await Authenticate();
            var response = await PostAsync<CreatePublicationRequest, CreatePublicationResponse>(request);
            var errorMessage = _errorMessages.FirstOrDefault();

            Assert.Equal(nameof(request.AuthorIds), errorMessage.Key);
            Assert.Equal(ErrorMessages.EntityExists, errorMessage.Value[0]);
        }

        [Fact]
        public async Task GetAllPublications_Test()
        {
            var createPublicationRequest = TestData.CreatePublicationRequest;
            var getAllPublicationsRequest = new GetAllPublicationsRequest() { QueryString = new { Include = nameof(PublicationEntity.AuthorsPublications) } };
            createPublicationRequest.AuthorIds = new List<int>() { 1, 2 };

            await Authenticate();
            await PostAsync<CreatePublicationRequest, List<int>>(createPublicationRequest);
            var response = await GetAsync<GetAllPublicationsRequest, IEnumerable<CreatePublicationResponse>>(getAllPublicationsRequest);

            response.ToList().ForEach(publication =>
            {
                Assert.Equal(createPublicationRequest.Text, publication.Text);
                Assert.Equal(createPublicationRequest.Title, publication.Title);
                Assert.Equal(string.Join("", createPublicationRequest.AuthorIds), string.Join("", publication.AuthorsPublications.Select(n => n.AuthorId)));
            });
        }
    }
}
