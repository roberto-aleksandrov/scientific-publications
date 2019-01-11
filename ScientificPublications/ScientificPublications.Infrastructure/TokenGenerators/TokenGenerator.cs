namespace Calendar.Utilities.TokenGenerators
{
    using Microsoft.IdentityModel.Tokens;
    using ScientificPublications.Application.Interfaces.Authentication;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;

    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(IDictionary<string, string> payload, string secretKey, string iss, string audience, double expirationHours)
        {
            Claim[] claims = payload.Select(n => new Claim(n.Key, n.Value)).ToArray();

            SigningCredentials credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: iss,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddHours(expirationHours),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public T Decode<T>(string token, string secret)
        {
            return default(T);
        }

        public string Decode(string token, string secret)
        {
            return null;
        }
    }
}
