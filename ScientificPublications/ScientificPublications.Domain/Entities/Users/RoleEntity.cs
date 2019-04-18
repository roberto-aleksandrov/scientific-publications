using ScientificPublications.Domain.Enums;
using System.Collections.Generic;

namespace ScientificPublications.Domain.Entities.Users
{
    public class RoleEntity : BaseEntity
    {
        public RoleEntity()
        {
            UserRoles = new List<UserRoleEntity>();
        }

        public int Id { get; set; }

        public Role Role { get; set; }

        public ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
