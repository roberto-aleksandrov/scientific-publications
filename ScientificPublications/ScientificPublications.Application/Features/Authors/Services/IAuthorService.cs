using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Domain.Entities.Users;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Authors.Services
{
    public interface IAuthorService
    {
        Task<AuthorEntity> CreateAuthorByUserAsync(CreateAuthorCommand createAuthorCommand, UserEntity userEntity);
    }
}
