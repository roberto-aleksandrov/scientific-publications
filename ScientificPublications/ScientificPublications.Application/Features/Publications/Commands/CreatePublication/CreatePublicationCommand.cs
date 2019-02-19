using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Features.Publications.Models;
using System.Collections.Generic;

namespace ScientificPublications.Application.Features.Publications.Commands.CreatePublication
{
    public class CreatePublicationCommand : BaseRequest<PublicationDto>
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public ICollection<int> AuthorIds { get; set; }
    }
}
