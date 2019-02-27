using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ScientificPublications.Application.Common.Services;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Spcifications.Roles;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Domain.Enums;

namespace ScientificPublications.Application.Features.Authors.Services
{
    public class AuthorService : Service, IAuthorService
    {
        public AuthorService(IData data, IMapper mapper) 
            : base(data, mapper)
        {
        }

        public async Task<AuthorEntity> CreateAuthorByUserAsync(CreateAuthorCommand createAuthorCommand, UserEntity userEntity)
        {
            var author = _mapper.Map<AuthorEntity>(createAuthorCommand);

            var role = (await _data.Roles.ListAsync(new GetRolesSpecification(Role.Author))).First();

            userEntity.UserRoles.Add(new UserRoleEntity { Role = role });


            author.User = userEntity;

            return author;
        }
    }
}
