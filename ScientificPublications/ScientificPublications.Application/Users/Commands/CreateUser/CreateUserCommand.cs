using MediatR;

namespace ScientificPublications.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<object>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
