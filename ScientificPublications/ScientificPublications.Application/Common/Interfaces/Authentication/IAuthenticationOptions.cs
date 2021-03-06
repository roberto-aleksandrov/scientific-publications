namespace ScientificPublications.Application.Common.Interfaces.Authentication
{
    public interface IAuthenticationOptions
    {
        string SecretKey { get; }

        string Iss { get; }

        string Audience { get; }

        double ExpirationHours { get; }
    }
}
