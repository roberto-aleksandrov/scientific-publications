using System.Collections.Generic;

namespace ScientificPublications.Application.Interfaces.Authentication
{
    public interface ITokenGenerator
    {
        string GenerateToken(IDictionary<string, string> payload, string secretKey, string iss, string audience, double expirationHours);

        T Decode<T>(string token, string secret);

        string Decode(string token, string secret);
    }
}
