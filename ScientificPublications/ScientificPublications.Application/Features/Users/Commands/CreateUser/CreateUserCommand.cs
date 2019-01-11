using MediatR;

namespace ScientificPublications.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<object>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
