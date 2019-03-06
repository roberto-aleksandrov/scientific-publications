using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Domain.Entities.Publications;
using System.Collections.Generic;

namespace ScientificPublications.Application.Features.Publications.Commands.CreatePublication
{
    public class CreatePublicationCommand : BaseCommand<PublicationEntity>
    {
        public string ScopusId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public ICollection<int> AuthorIds { get; set; }
    }
}
