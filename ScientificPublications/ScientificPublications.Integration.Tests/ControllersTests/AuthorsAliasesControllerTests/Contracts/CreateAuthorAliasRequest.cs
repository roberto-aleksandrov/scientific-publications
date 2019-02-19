namespace ScientificPublications.Integration.Tests.ControllersTests.AuthorsAliasesControllerTests.Contracts
{
    public class CreateAuthorAliasRequest
    {
        public string Alias { get; set; }

        public int AuthorId { get; set; }
    }
}
