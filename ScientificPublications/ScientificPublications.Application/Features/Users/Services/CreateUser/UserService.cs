using System.Threading.Tasks;
using AutoMapper;
using ScientificPublications.Application.Common.Services;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.Users.Services.CreateUser
{
    public class UserService : Service, IUserService
    {
        public UserService(IData data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public Task<UserEntity> CreateUserAsync(RegisterUserCommand registerUserCommand)
        {
            var userEntity = _mapper.Map<UserEntity>(registerUserCommand);

            return Task.FromResult(userEntity);
        }
    }
}
