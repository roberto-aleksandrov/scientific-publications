using ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests.Contracts;
using ScientificPublications.Integration.Tests.Factories;
using ScientificPublications.WebUI;
using System.Threading.Tasks;
using Xunit;

namespace ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests
{
    public class UsersControllerTests : ControllerTests
    {
        public UsersControllerTests(CustomWebApplicationFactory<Startup> factory)
            : base(factory) { }

        [Fact]
        public async Task Register()
        {
            var model = new RegisterRequest { Username = "test", Password = "blablabla" };

            var response = await PostAsync<RegisterRequest, RegisterResponse>(model);

            Assert.Equal(model.Username, response.Username);
        }

    }
}
