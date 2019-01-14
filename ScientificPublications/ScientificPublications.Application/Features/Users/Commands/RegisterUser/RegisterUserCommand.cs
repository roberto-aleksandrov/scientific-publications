using MediatR;

namespace ScientificPublications.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<object>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
