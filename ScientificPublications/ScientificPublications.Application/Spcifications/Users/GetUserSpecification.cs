using ScientificPublications.Domain.Entities.Users;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Application.Spcifications.Users
{
    public class GetUserSpecification : BaseSpecification<UserEntity>
    {
        public GetUserSpecification(string username)
            : base(n => n.Username == username) { }

        public GetUserSpecification(IEnumerable<int> userIds)
            : base(n => userIds.Contains(n.Id)) { }
    }
}
