using ScientificPublications.Integration.Tests.Attributes;
using ScientificPublications.Integration.Tests.Contracts;
using ScientificPublications.Integration.Tests.ControllersTests.AuthorsAliasesControllerTests.Contracts;
using ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests.Contracts;
using System.Collections.Generic;

namespace ScientificPublications.Integration.Tests.ControllersTests.Authors.Contracts
{
    [Endpoint("Create")]
    public class RegisterAuthorResponse : Response
    {
        public string ScopusId { get; set; }

        public int UserId { get; set; }

        public RegisterUserResponse User { get; set; }

        public ICollection<CreateAuthorAliasResponse> Aliases { get; set; }
    }
}
