using ScientificPublications.Domain.Entities.AuthorsPublications;
using System.Collections.Generic;

namespace ScientificPublications.Domain.Entities.Users
{
    public class AuthorEntity : Entity
    {
        public AuthorEntity()
        {
            AuthorsPublications = new List<AuthorPublicationEntity>();
        }
        
        public int UserId { get; set; }

        public UserEntity User { get; set; }

        public string ScopusId { get; set; }

        public ICollection<AuthorPublicationEntity> AuthorsPublications { get; set; }
    }
}
