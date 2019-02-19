using System.Collections.Generic;

namespace ScientificPublications.Application.Features.Publications.Models
{
    public class PublicationDto
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public ICollection<AuthorPublicationDto> AuthorsPublications { get; set; }
    }
}
