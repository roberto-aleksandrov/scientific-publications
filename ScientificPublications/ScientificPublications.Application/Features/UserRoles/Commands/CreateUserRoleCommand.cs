using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Domain.Enums;

namespace ScientificPublications.Application.Features.UserRoles.Commands
{
    public class CreateUserRoleCommand : BaseRequest<object>
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}
