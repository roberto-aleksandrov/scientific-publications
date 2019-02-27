using AutoMapper;
using ScientificPublications.Application.Features.Authors.Models;
using ScientificPublications.Domain.Entities.Users;
using System.Linq;

namespace ScientificPublications.Application.Features.Authors.Automapper.Profiles
{
    public class AuthorEntityToDtoProfile : Profile
    {
        public AuthorEntityToDtoProfile()
        {
            CreateMap<AuthorEntity, AuthorDto>();
                //.ForPath(dto => dto.User.UserRoles, otps => otps.MapFrom(entity => entity.User.UserRoles.ToList()));
        }
    }
}
