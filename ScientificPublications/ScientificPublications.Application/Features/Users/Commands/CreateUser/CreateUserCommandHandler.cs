using MediatR;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Interfaces.Hasher;
using ScientificPublications.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, object>
    {
        private readonly IData _data;
        private readonly IHasher _hasher;

        public CreateUserCommandHandler(IData data, IHasher hasher)
        {
            _data = data;
            _hasher = hasher;
        }

        public async Task<object> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = _hasher.Create(request.Password)
            };

            return await _data.Users.AddAsync(user);
        }
    }
}
