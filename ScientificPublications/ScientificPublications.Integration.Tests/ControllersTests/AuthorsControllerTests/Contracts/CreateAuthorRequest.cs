using System.Collections.Generic;

namespace ScientificPublications.Integration.Tests.ControllersTests.AuthorsControllerTests.Contracts
{
    public class CreateAuthorRequest
    {
        public bool IsCathedralMember { get; set; }

        public string ScopusId { get; set; }

        public ICollection<string> Aliases { get; set; }
    }
}
