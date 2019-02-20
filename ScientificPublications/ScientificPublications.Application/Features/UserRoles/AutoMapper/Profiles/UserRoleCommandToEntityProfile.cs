using AutoMapper;
using ScientificPublications.Application.Features.UserRoles.Commands;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.UserRoles.AutoMapper.Profiles
{
    public class UserRoleCommandToEntityProfile : Profile
    {
        public UserRoleCommandToEntityProfile()
        {
            CreateMap<CreateUserRoleCommand, UserRoleEntity>();
        }
    }
}
