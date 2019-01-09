using MediatR;

namespace ScientificPublications.Application.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
