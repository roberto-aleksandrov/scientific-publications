using AutoMapper;
using ScientificPublications.Application.Common.Interfaces.Authentication;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Common.Spcifications.Users;
using ScientificPublications.Application.Features.Users.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Users.Queries.Login
{
    public class LoginQueryHandler : BaseRequestHandler<LoginQuery, LoginDto>
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IAuthenticationOptions _authenticationOptions;

        public LoginQueryHandler(IData data, IMapper mapper, ITokenGenerator tokenGenerator, IAuthenticationOptions authenticationOptions)
            : base(data, mapper)
        {
            _tokenGenerator = tokenGenerator;
            _authenticationOptions = authenticationOptions;
        }

        public override async Task<LoginDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = (await _data.Users.ListAsync(new GetUserSpecification(request.Username))).First();
            var roles = new List<string>();

            var payload = new Dictionary<string, string>
            {
                {JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString() },
                {ClaimsIdentity.DefaultNameClaimType, request.Username }
            };

            if (user != null)
            {
                roles.Add("");
            }

            var token = _tokenGenerator.GenerateToken(payload,
                _authenticationOptions.SecretKey,
                _authenticationOptions.Iss,
                _authenticationOptions.Audience,
                _authenticationOptions.ExpirationHours);

            return new LoginDto { Token = token };
        }
    }
}
