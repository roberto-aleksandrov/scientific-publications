using MediatR;
using ScientificPublications.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private IRepository<Domain.Entities.User> _repository;

        public CreateUserCommandHandler(IRepository<Domain.Entities.User> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(new Domain.Entities.User { UserName = request.UserName, Password = request.Password });

            return Unit.Value;
        }
    }
}
