using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.Authors.Commands.RegisterAuthor
{
    public class RegisterAuthorCommand : BaseCommand<AuthorEntity>
    {
        public RegisterUserCommand RegisterUser { get; set; }

        public CreateAuthorCommand CreateAuthor { get; set; }
    }
}
