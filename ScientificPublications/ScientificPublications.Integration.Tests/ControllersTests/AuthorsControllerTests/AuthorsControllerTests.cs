using Microsoft.EntityFrameworkCore;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Domain.Enums;
using ScientificPublications.Integration.Tests.ControllersTests.Authors.Contracts;
using ScientificPublications.Integration.Tests.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            request.CreateAuthor.IsCathedralMember = authorType == typeof(CathedralAuthorEntity);

            var response = await PostAsync<RegisterAuthorRequest, List<int>>(request);

            var author = _factory.Context.Authors
                .Include(n => n.User)
                .Include(n => n.Aliases)
                .First(n => n.Id == response.Content.First());

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(request.RegisterUser.Username, author.User.Username);
            Assert.Equal(request.CreateAuthor.ScopusId, author.ScopusId);
            Assert.Equal(authorType, author.InstanceType);
            Assert.Equal(string.Join("", request.CreateAuthor.Aliases), string.Join("", author.Aliases.Select(n => n.Alias)));
        }

        [Fact]
        public async Task CreateAuthor_UsernameExists_Test()
        {
            var user = _factory.Seeder.Seed<UserEntity>();
            var request = TestData.CreateAuthorRequest;
            request.RegisterUser.Username = user.Username;

            var response = await PostAsync<RegisterAuthorRequest, List<int>>(request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal(nameof(request.RegisterUser.Username), response.ErrorMessages?.FirstOrDefault().Key);
        }

        [Fact]
        public async Task CreateAuthor_ScopusIdExists_Test()
        {
            var author = _factory.Seeder.Seed<AuthorEntity>();
            var request = TestData.CreateAuthorRequest;
            request.CreateAuthor.ScopusId = author.ScopusId;

            var response = await PostAsync<RegisterAuthorRequest, List<int>>(request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal(nameof(request.CreateAuthor.ScopusId), response.ErrorMessages?.FirstOrDefault().Key);
        }
    }
}
