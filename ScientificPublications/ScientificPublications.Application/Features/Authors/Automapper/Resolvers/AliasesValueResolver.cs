using AutoMapper;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Domain.Entities.Users;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Application.Features.Authors.Automapper.Resolvers
{
    public class AliasesValueResolver : IValueResolver<CreateAuthorCommand, AuthorEntity, ICollection<AuthorAliasEntity>>
    {
        public ICollection<AuthorAliasEntity> Resolve(CreateAuthorCommand source, AuthorEntity destination, ICollection<AuthorAliasEntity> destMember, ResolutionContext context)
        {
            return source.Aliases.Select(a => new AuthorAliasEntity { Alias = a }).ToList();
        }
    }
}
