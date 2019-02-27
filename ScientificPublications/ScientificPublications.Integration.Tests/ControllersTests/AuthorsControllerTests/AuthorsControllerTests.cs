using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Domain.Enums;
using ScientificPublications.Integration.Tests.ControllersTests.Authors.Contracts;
using ScientificPublications.Integration.Tests.Seed;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ScientificPublications.Integration.Tests.ControllersTests.Authors
{
    public class AuthorsControllerTests : ControllerTests
    {
        [Theory]
        [InlineData(typeof(CathedralAuthorEntity))]
        [InlineData(typeof(NonCathedralAuthorEntity))]
        public async Task CreateAuthor_Test(Type authorType)
        {
            var request = TestData.CreateAuthorRequest;
            request.IsCathedralMember = authorType == typeof(CathedralAuthorEntity);

            var response = await PostAsync<CreateAuthorRequest, CreateAuthorResponse>(request);

            Assert.Equal(request.RegisterUser.Username, response.User.Username);
            Assert.Equal(request.ScopusId, response.ScopusId);
            Assert.Equal(authorType, response.InstanceType);
            Assert.Equal(string.Join("", request.Aliases), string.Join("", response.Aliases.Select(n => n.Alias)));
        }

        [Fact]
        public async Task CreateAuthor_UsernameExists_Test()
        {
            var request = TestData.CreateAuthorRequest;
            request.RegisterUser.Username = "test";

            await PostAsync<CreateAuthorRequest, CreateAuthorResponse>(request);

            Assert.Equal($"{nameof(request.RegisterUser)}.{nameof(request.RegisterUser.Username)}", _errorMessages?.FirstOrDefault().Key);
        }

        [Fact]
        public async Task CreateAuthor_ScopusIdExists_Test()
        {
            var request = TestData.CreateAuthorRequest;
            request.ScopusId = SeedData.Authors[0].ScopusId;

            await PostAsync<CreateAuthorRequest, CreateAuthorResponse>(request);

            Assert.Equal(nameof(request.ScopusId), _errorMessages?.FirstOrDefault().Key);
        }
    }
}
