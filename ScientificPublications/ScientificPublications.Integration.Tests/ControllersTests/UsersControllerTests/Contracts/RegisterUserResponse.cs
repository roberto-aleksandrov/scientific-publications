using ScientificPublications.Integration.Tests.Attributes;
using ScientificPublications.Integration.Tests.Contracts;

namespace ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests.Contracts
{
    [Endpoint("Register")]
    public class RegisterUserResponse : Response
    {
        public string Username { get; set; }

    }
}
