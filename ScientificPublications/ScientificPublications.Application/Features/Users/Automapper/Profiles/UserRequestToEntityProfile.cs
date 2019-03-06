using AutoMapper;
using ScientificPublications.Application.Features.Users.AutoMapper.Resolvers;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.Users.AutoMapper.Profiles
{
    public class UserRequestToEntityProfile : Profile
    {
        public UserRequestToEntityProfile()
        {
            CreateMap<RegisterUserCommand, UserEntity>()
                .ConvertUsing<UserEntityTypeConverter>();
        }
    }
}
