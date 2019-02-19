using ScientificPublications.Integration.Tests.Attributes;

namespace ScientificPublications.Integration.Tests.Contracts
{
    [Endpoint("Users", "Login")]
    public class LoginRequest : Request
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
