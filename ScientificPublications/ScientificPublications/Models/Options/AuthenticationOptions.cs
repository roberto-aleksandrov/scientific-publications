using ScientificPublications.Application.Interfaces.Authentication;

namespace ScientificPublications.WebUI.Models.Options
{
    public class AuthenticationOptions : IAuthenticationOptions
    {
        public string SecretKey { get; set; }

        public string Iss { get; set; }

        public string Audience { get; set; }

        public double ExpirationHours { get; set; }
    }
}
