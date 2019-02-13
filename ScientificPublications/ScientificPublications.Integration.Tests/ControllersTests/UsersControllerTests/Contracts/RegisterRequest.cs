using ScientificPublications.Integration.Tests.ControllersTests.Contracts;

namespace ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests.Contracts
{
    public class RegisterRequest : Request
    { 
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
