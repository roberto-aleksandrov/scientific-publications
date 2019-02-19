using ScientificPublications.Integration.Tests.ControllersTests.Authors.Contracts;
using ScientificPublications.Integration.Tests.ControllersTests.PublicationsControllerTests.Contracts;
using System.Collections.Generic;

namespace ScientificPublications.Integration.Tests
{
    public static class TestData
    {
        public static CreateAuthorRequest CreateAuthorRequest => new CreateAuthorRequest
        {
            Username = "test123",
            Password = "blablabla",
            ScopusId = "1231234142",
            Aliases = new List<string>() { "test", "Test" }
        };
        public static CreatePublicationRequest CreatePublicationRequest => new CreatePublicationRequest
        {
            Title = "test title",
            Text = "test text",
            AuthorIds = new List<int>() { 1 }
        };
    }
}
