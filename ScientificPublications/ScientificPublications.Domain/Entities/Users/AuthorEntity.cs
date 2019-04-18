using ScientificPublications.Domain.Entities.AuthorsPublications;
using System.Collections.Generic;

namespace ScientificPublications.Domain.Entities.Users
{
    public class AuthorEntity : BaseEntity
    {
        public AuthorEntity()
        {
            AuthorsPublications = new List<AuthorPublicationEntity>();
            Aliases = new List<AuthorAliasEntity>();
        }

        public int Id { get; set; }

        public string ScopusId { get; set; }

        public int? UserId { get; set; }

        public UserEntity User { get; set; }

        public ICollection<AuthorPublicationEntity> AuthorsPublications { get; set; }

        public ICollection<AuthorAliasEntity> Aliases { get; set; }
    }
}
