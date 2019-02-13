using ScientificPublications.Application.Common.Requests;

namespace ScientificPublications.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : BaseRequest<RegisterUserViewModel>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
