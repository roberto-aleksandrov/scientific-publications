using ScientificPublications.Application.Common.Spcifications;
using ScientificPublications.Domain.Entities.AuthorsPublications;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.Authors.Specifications
{
    public class GetScopusAuthorsSpecification : BaseSpecification<AuthorEntity>
    {
        public GetScopusAuthorsSpecification(string scopusId)
            : base(n => n.ScopusId == scopusId)
        {
        }

        public GetScopusAuthorsSpecification()
            : base(n => n.ScopusId != null)
        {
            AddInclude($"{nameof(AuthorEntity.AuthorsPublications)}.{nameof(AuthorPublicationEntity.Publication)}");
        }
    }
}
