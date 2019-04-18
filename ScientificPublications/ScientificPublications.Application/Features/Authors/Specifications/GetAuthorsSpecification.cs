using ScientificPublications.Application.Common.Spcifications;
using ScientificPublications.Domain.Entities.Users;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Application.Features.Authors.Specifications
{
    public class GetAuthorsSpecification : BaseSpecification<AuthorEntity>
    {
        public GetAuthorsSpecification(int id)
            : base(n => n.Id == id)
        {
        }

        public GetAuthorsSpecification(IEnumerable<int> ids)
            : base(n => ids.Contains(n.Id))
        {
        }
    }
}
