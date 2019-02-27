using AutoMapper;
using ScientificPublications.Application.Features.Authors.Models;
using ScientificPublications.Application.Features.AuthorsAliases.Models;
using ScientificPublications.Application.Features.Publications.Commands.CreatePublication;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<AuthorAliasEntity, AuthorAliasDto>();
        }
    }
}
