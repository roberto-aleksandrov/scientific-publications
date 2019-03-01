using ScientificPublications.Application.Spcifications;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.Authors.Specifications
{
    public class GetScopusAuthorsSpecification : BaseSpecification<AuthorEntity>
    {
        public GetScopusAuthorsSpecification()
            : base(n => n.ScopusId != null)
        {
            AddInclude(n => n.AuthorsPublications);
        }
    }
}
