using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Domain.Entities.Users;
using System.Collections.Generic;

namespace ScientificPublications.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : BaseCommand<AuthorEntity>
    {
        public RegisterUserCommand RegisterUser { get; set; }

        public string ScopusId { get; set; }

        public bool IsCathedralMember { get; set; }

        public ICollection<string> Aliases { get; set; }
    }
}
