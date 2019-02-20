using System.Collections.Generic;

namespace ScientificPublications.Domain.Entities.Users
{
    public class UserEntity : BaseEntity
    {
        public UserEntity()
        {
            UserRoles = new List<UserRoleEntity>();
        }

        public int Id { get; set; }

        public AuthorEntity Author { get; set; }

        public ICollection<UserRoleEntity> UserRoles { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

    }
}
