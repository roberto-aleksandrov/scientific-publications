using MediatR;

namespace ScientificPublications.Application.Features.Users.Queries
{
    public class LoginQuery : IRequest<LoginViewModel>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
