using ScientificPublications.Application.Common.ViewModels;
using ScientificPublications.Application.Features.AuthorsAliases.Models;
using ScientificPublications.Application.Features.Users.Models;
using System.Collections.Generic;

namespace ScientificPublications.Application.Features.Authors.Models
{
    public class AuthorDto : BaseDto
    {
        public string ScopusId { get; set; }

        public int UserId { get; set; }

        public UserDto User { get; set; }

        public ICollection<AuthorAliasDto> Aliases { get; set; }
    }
}
