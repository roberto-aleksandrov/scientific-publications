using AutoMapper;
using ScientificPublications.Application.Features.Authors.Automapper.Resolvers;
using ScientificPublications.Application.Features.Authors.Automapper.TypeConverters;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Application.Features.Authors.Commands.RegisterAuthor;
using ScientificPublications.Application.Features.AuthorsAliases.Commands.CreateAuthorAlias;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.Authors.Automapper.Profiles
{
    public class RequestToEntityProfile : Profile
    {
        public RequestToEntityProfile()
        {
            CreateMap<CreateAuthorCommand, AuthorEntity>()
                .Include<CreateAuthorCommand, CathedralAuthorEntity>()
                .Include<CreateAuthorCommand, NonCathedralAuthorEntity>()
                .ForMember(entity => entity.Aliases, opts => opts.MapFrom<AliasesValueResolver>())
                .ConvertUsing<AuthorEntityTypeConverter>();

            CreateMap<CreateAuthorCommand, CathedralAuthorEntity>();

            CreateMap<CreateAuthorCommand, NonCathedralAuthorEntity>();

            CreateMap<CreateAuthorAliasCommand, AuthorAliasEntity>();
        }
    }
}
