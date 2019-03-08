using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Domain.Enums;

namespace ScientificPublications.Application.Features.Roles.Commands
{
    public class AssignUserRoleCommand : BaseCommand<UserRoleEntity>
    {
        public int UserId { get; set; }

        public Role Role { get; set; }
    }
}
