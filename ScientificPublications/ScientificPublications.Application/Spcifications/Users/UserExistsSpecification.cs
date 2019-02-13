using ScientificPublications.Domain.Entities.Users;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Application.Spcifications.Users
{
    public class UserExistsSpecification : BaseSpecification<UserEntity>
    {
        public UserExistsSpecification(string username)
            : base(n => n.Username == username) { }

        public UserExistsSpecification(IEnumerable<int> userIds)
            : base(n => userIds.Contains(n.Id)) { }
    }
}
