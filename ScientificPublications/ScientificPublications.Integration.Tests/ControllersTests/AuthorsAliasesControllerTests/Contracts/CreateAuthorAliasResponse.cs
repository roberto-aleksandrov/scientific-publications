using ScientificPublications.Integration.Tests.Contracts;

namespace ScientificPublications.Integration.Tests.ControllersTests.AuthorsAliasesControllerTests.Contracts
{
    public class CreateAuthorAliasResponse : ResponseContent
    {
        public string Alias { get; set; }

        public int AuthorId { get; set; }

    }
}
