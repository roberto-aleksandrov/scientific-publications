using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Domain.Entities.AuthorsPublications
{
    public class AuthorPublicationEntity : BaseEntity
    {
        public int AuthorId { get; set; }

        public AuthorEntity Author { get; set; }

        public int PublicationId { get; set; }

        public PublicationEntity Publication { get; set; }
    }
}
