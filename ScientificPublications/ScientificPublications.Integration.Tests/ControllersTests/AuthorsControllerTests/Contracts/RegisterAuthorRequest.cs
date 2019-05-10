using ScientificPublications.Integration.Tests.Attributes;
using ScientificPublications.Integration.Tests.Contracts;
using ScientificPublications.Integration.Tests.ControllersTests.AuthorsControllerTests.Contracts;
using ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests.Contracts;
using ScientificPublications.WebUI.Controllers;

namespace ScientificPublications.Integration.Tests.ControllersTests.Authors.Contracts
{
    [Endpoint(nameof(AuthorsController.Create))]
    public class RegisterAuthorRequest : Request
    {
        public RegisterUserRequest RegisterUser { get; set; }

        public CreateAuthorRequest CreateAuthor { get; set; }
    }
}
