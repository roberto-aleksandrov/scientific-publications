using MediatR;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Interfaces.Hasher;
using ScientificPublications.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, object>
    {
        private readonly IData _data;
        private readonly IHasher _hasher;

        public RegisterUserCommandHandler(IData data, IHasher hasher)
        {
            _data = data;
            _hasher = hasher;
        }

        public async Task<object> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var salt = Guid.NewGuid().ToString();
            var user = new User
            {
                Username = request.Username,
                Password = _hasher.Create(request.Password),
                Salt = salt
            };

            return await _data.Users.AddAsync(user);
        }
    }
}
