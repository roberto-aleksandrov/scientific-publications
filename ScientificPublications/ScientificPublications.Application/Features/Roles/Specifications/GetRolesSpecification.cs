using ScientificPublications.Application.Common.Spcifications;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Domain.Enums;

namespace ScientificPublications.Application.Features.Roles.Specifications
{
    public class GetRolesSpecification : BaseSpecification<RoleEntity>
    {
        public GetRolesSpecification(Role role)
           : base(r => r.Role == role) { }

    }
}
