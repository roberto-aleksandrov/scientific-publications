using ScientificPublications.Application.Common.ViewModels;
using ScientificPublications.Application.Features.UserRoles.Models;
using System.Collections.Generic;

namespace ScientificPublications.Application.Features.Users.Models
{
    public class UserDto : BaseDto
    {
        public int? AuthorId { get; set; }

        public string Username { get; set; }

        public ICollection<UserRoleDto> UserRoles { get; set; }
    }
}
