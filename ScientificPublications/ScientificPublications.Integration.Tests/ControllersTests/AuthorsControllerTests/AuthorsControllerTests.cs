using Microsoft.EntityFrameworkCore;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Domain.Enums;
using ScientificPublications.Integration.Tests.ControllersTests.Authors.Contracts;
using ScientificPublications.Integration.Tests.Seed;
using System;
using System.Collections.Generic;
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

            var response = await PostAsync<CreateAuthorRequest, List<int>>(request);

            var author = _factory.Context.Authors
                .Include(n => n.User)
                .Include(n => n.Aliases)
                .First(n => n.Id == response.First());

            Assert.Equal(request.RegisterUser.Username, author.User.Username);
            Assert.Equal(request.ScopusId, author.ScopusId);
            Assert.Equal(authorType, author.InstanceType);
            Assert.Equal(string.Join("", request.Aliases), string.Join("", author.Aliases.Select(n => n.Alias)));
        }

        [Fact]
        public async Task CreateAuthor_UsernameExists_Test()
        {
            var request = TestData.CreateAuthorRequest;
            request.RegisterUser.Username = "test";

            await PostAsync<CreateAuthorRequest, CreateAuthorResponse>(request);

            Assert.Equal(nameof(request.RegisterUser.Username), _errorMessages?.FirstOrDefault().Key);
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
