using ScientificPublications.Integration.Tests.Attributes;
using ScientificPublications.Integration.Tests.Contracts;

namespace ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests.Contracts
{
    [Endpoint("Register")]
    public class RegisterUserResponse : ResponseContent
    {
        public string Username { get; set; }

    }
}
