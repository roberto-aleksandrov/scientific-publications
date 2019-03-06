using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : BaseCommand<UserEntity>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
