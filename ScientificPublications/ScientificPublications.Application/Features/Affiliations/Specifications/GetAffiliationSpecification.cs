using ScientificPublications.Application.Common.Spcifications;
using ScientificPublications.Domain.Entities.Affiliations;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Application.Features.Affiliations.Specifications
{
    public class GetAffiliationSpecification : BaseSpecification<AffiliationEntity>
    {
        public GetAffiliationSpecification(int id)
            : base(n => n.Id == id)
        {
        }

        public GetAffiliationSpecification(IEnumerable<int> ids)
            : base(n => ids.Contains(n.Id))
        {
        }
    }
}
