using MediatR;
using ScientificPublications.Application.Interfaces;
using ScientificPublications.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, object>
    {
        private readonly IData _data;

        public CreateUserCommandHandler(IData data)
        {
            _data = data;
        }

        public async Task<object> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = request.UserName,
                Password = request.Password
            };

            return await _data.Users.AddAsync(user);
        }
    }
}
