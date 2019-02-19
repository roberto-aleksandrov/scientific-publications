using ScientificPublications.Application.Features.Publications.Models;
using ScientificPublications.Integration.Tests.Attributes;
using ScientificPublications.Integration.Tests.Contracts;
using System.Collections.Generic;

namespace ScientificPublications.Integration.Tests.ControllersTests.PublicationsControllerTests.Contracts
{
    [Endpoint("Create")]
    public class CreatePublicationResponse : Response
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public ICollection<AuthorPublicationDto> AuthorsPublications { get; set; }
    }
}
