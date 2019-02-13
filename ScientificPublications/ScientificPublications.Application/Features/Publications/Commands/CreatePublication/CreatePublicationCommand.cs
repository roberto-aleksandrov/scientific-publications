using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Features.Publications.Models;
using System.Collections.Generic;

namespace ScientificPublications.Application.Features.Publications.Commands.CreatePublication
{
    public class CreatePublicationCommand : BaseRequest<CreatePublicationViewModel>
    {
        public string Text { get; set; }

        public ICollection<AuthorPublicationDto> AuthorsPublications { get; set; }
    }
}
