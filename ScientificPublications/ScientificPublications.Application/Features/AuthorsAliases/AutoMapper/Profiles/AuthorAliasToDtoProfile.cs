using AutoMapper;
using ScientificPublications.Application.Features.AuthorsAliases.Models;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.AuthorsAliases.AutoMapper.Profiles
{
    public class AuthorAliasToDtoProfile : Profile
    {
        public AuthorAliasToDtoProfile()
        {
            CreateMap<AuthorAliasEntity, AuthorAliasDto>();
        }
    }
}
