using ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests
{
    public class UsersControllerTests : ControllerTests
    {
        public UsersControllerTests() { }

        [Fact]
        public async Task Register()
        {
            var model = new RegisterUserRequest { Username = "test21312", Password = "blablabla" };

            var response = await PostAsync<RegisterUserRequest, List<int>>(model);

            var user = _factory.Context.Users.Find(response.Content.First());

            Assert.Equal(model.Username, user.Username);
        }

    }
}
