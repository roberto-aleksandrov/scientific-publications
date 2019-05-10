using ScientificPublications.Integration.Tests.Attributes;
using ScientificPublications.Integration.Tests.Contracts;
using ScientificPublications.WebUI.Controllers;

namespace ScientificPublications.Integration.Tests.ControllersTests.PublicationsControllerTests.Contracts
{
    [Endpoint(nameof(PublicationsController.GetAll))]
    public class GetAllPublicationsRequest : Request
    {
    }
}
