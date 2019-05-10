using ScientificPublications.Integration.Tests.Attributes;
using ScientificPublications.Integration.Tests.Contracts;
using ScientificPublications.WebUI.Controllers;

namespace ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests.Contracts
{
    [Endpoint(nameof(UsersController.Register))]
    public class RegisterUserRequest : Request
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
