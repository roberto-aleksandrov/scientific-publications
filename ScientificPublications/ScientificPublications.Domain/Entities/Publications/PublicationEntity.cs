﻿using ScientificPublications.Domain.Entities.AuthorsPublications;
using System.Collections.Generic;

namespace ScientificPublications.Domain.Entities.Publications
{
    public class PublicationEntity : BaseEntity
    {
        public PublicationEntity()
        {
            AuthorsPublications = new List<AuthorPublicationEntity>();
        }

        public int Id { get; set; }
        
        public string ScopusId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public ICollection<AuthorPublicationEntity> AuthorsPublications { get; set; }
    }
}
