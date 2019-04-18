using ScientificPublications.Application.Common.Spcifications;
using ScientificPublications.Domain.Entities.Affiliations;

namespace ScientificPublications.Application.Features.Affiliations.Specifications
{
    public class GetScopusAffiliationsSpecification : BaseSpecification<AffiliationEntity>
    {
        public GetScopusAffiliationsSpecification(string scopusId)
            : base(n => n.ScopusId == scopusId)
        {
        }

        public GetScopusAffiliationsSpecification()
            : base(n => n.ScopusId != null)
        {
        }
    }
}
