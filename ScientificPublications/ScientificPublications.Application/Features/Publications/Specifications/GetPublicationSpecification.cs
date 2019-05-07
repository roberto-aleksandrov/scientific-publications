using ScientificPublications.Application.Common.Spcifications;
using ScientificPublications.Domain.Entities.Publications;

namespace ScientificPublications.Application.Features.Publications.Specifications
{
    public class GetPublicationSpecification : BaseSpecification<PublicationEntity>
    {
        public GetPublicationSpecification(int id)
            : base(n => n.Id == id)
        {

        }
    }
}
