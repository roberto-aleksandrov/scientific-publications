using AutoMapper;
using ScientificPublications.Application.Features.Authors.Models;
using ScientificPublications.Application.Features.Publications.Models;
using ScientificPublications.Domain.Entities.AuthorsPublications;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.Authors.Automapper.Profiles
{
    public class AuthorEntityToDtoProfile : Profile
    {
        public AuthorEntityToDtoProfile()
        {
            CreateMap<AuthorEntity, AuthorDto>();
        }
    }
}
