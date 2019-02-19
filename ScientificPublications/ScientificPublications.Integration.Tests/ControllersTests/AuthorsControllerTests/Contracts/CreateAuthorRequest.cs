using ScientificPublications.Integration.Tests.Attributes;
using ScientificPublications.Integration.Tests.Contracts;
using System.Collections.Generic;

namespace ScientificPublications.Integration.Tests.ControllersTests.Authors.Contracts
{
    [Endpoint("Create")]
    public class CreateAuthorRequest : Request
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsCathedralMember { get; set; }

        public string ScopusId { get; set; }

        public ICollection<string> Aliases { get; set; }
    }
}
