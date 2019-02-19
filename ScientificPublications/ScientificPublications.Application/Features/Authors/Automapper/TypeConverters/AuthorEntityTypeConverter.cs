using AutoMapper;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.Authors.Automapper.TypeConverters
{
    public class AuthorEntityTypeConverter : ITypeConverter<CreateAuthorCommand, AuthorEntity>
    {
        public AuthorEntity Convert(CreateAuthorCommand request, AuthorEntity destination, ResolutionContext context)
        {
            return request.IsCathedralMember
                ? (AuthorEntity)context.Mapper.Map<CathedralAuthorEntity>(request)
                : context.Mapper.Map<NonCathedralAuthorEntity>(request);
        }
    }
}
