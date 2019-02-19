using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Features.Users.Models;

namespace ScientificPublications.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : BaseRequest<UserDto>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
