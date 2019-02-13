using MediatR;
using ScientificPublications.Application.Interfaces.Authentication;
using ScientificPublications.Application.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Users.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginViewModel>
    {
        private readonly IData _data;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IAuthenticationOptions _authenticationOptions;

        public LoginQueryHandler(IData data, ITokenGenerator tokenGenerator, IAuthenticationOptions authenticationOptions)
        {
            _data = data;
            _tokenGenerator = tokenGenerator;
            _authenticationOptions = authenticationOptions;
        }

        public async Task<LoginViewModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var payload = new Dictionary<string, string>
            {
                {JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString() },
                {ClaimsIdentity.DefaultNameClaimType, request.Username }
            };

            var token = _tokenGenerator.GenerateToken(payload,
                _authenticationOptions.SecretKey,
                _authenticationOptions.Iss,
                _authenticationOptions.Audience,
                _authenticationOptions.ExpirationHours);

            return new LoginViewModel { Token = token };
        }
    }
}
