using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Domain.Enums;

namespace ScientificPublications.Application.Spcifications.Roles
{
    public class GetRolesSpecification : BaseSpecification<RoleEntity>
    {
        public GetRolesSpecification(Role role)
           : base(r => r.Role == role) { }

    }
}
