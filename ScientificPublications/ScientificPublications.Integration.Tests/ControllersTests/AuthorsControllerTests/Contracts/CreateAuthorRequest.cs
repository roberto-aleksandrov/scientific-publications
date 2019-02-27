using ScientificPublications.Integration.Tests.Attributes;
using ScientificPublications.Integration.Tests.Contracts;
using ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests.Contracts;
using System.Collections.Generic;

namespace ScientificPublications.Integration.Tests.ControllersTests.Authors.Contracts
{
    [Endpoint("Create")]
    public class CreateAuthorRequest : Request
    {
        public RegisterUserRequest RegisterUser { get; set; }

        public bool IsCathedralMember { get; set; }

        public string ScopusId { get; set; }

        public ICollection<string> Aliases { get; set; }
    }
}
