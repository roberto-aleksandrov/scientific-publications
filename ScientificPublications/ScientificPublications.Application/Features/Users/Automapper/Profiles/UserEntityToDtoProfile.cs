using AutoMapper;
using ScientificPublications.Application.Features.Users.Models;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.Users.AutoMapper.Profiles
{
    public class UserEntityToDtoProfile : Profile
    {
        public UserEntityToDtoProfile()
        {
            CreateMap<UserEntity, UserDto>();
        }
    }
}
