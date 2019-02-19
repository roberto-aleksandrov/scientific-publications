using ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests.Contracts;
using System.Threading.Tasks;
using Xunit;

namespace ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests
{
    public class UsersControllerTests : ControllerTests
    {
        public UsersControllerTests() { }
        //: base(factory) { }

        [Fact]
        public async Task Register()
        {
            var model = new RegisterUserRequest { Username = "test21312", Password = "blablabla" };

            var response = await PostAsync<RegisterUserRequest, RegisterUserResponse>(model);

            Assert.Equal(model.Username, response.Username);
        }

    }
}
