using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Domain.Entities.Users;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Users.Services.CreateUser
{
    public interface IUserService
    {
        Task<UserEntity> CreateUserAsync(RegisterUserCommand registerUserCommand);
    }
}
