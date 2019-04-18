using ScientificPublications.Domain.Entities.Users;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Application.Common.Spcifications.Users
{
    public class GetUserSpecification : BaseSpecification<UserEntity>
    {
        public GetUserSpecification(int id)
            : base(n => n.Id == id) { }

        public GetUserSpecification(string username)
            : base(n => n.Username == username) { }

        public GetUserSpecification(IEnumerable<int> userIds)
            : base(n => userIds.Contains(n.Id)) { }
    }
}
