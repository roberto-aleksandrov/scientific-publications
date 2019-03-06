using ScientificPublications.Application.Common.Models.Mediatr;

namespace ScientificPublications.Application.Features.UserRoles.Commands
{
    public class CreateUserRoleCommand : BaseRequest<object>
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}
