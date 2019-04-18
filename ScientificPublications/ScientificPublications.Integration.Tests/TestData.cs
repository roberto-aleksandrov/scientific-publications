using ScientificPublications.Integration.Tests.ControllersTests.Authors.Contracts;
using ScientificPublications.Integration.Tests.ControllersTests.AuthorsControllerTests.Contracts;
using ScientificPublications.Integration.Tests.ControllersTests.PublicationsControllerTests.Contracts;
using ScientificPublications.Integration.Tests.ControllersTests.UsersControllerTests.Contracts;
using System.Collections.Generic;

namespace ScientificPublications.Integration.Tests
{
    public static class TestData
    {
        public static RegisterAuthorRequest CreateAuthorRequest => new RegisterAuthorRequest
        {
            RegisterUser = new RegisterUserRequest
            {
                Username = "test123",
                Password = "blablabla",
            },
          CreateAuthor = new CreateAuthorRequest
          {
              ScopusId = "1231234142",
              Aliases = new List<string>() { "test", "Test" }
          }
        };
        //public static CreatePublicationRequest CreatePublicationRequest => new CreatePublicationRequest
        //{
        //    Title = "test title",
        //    Text = "test text",
        //    AuthorIds = new List<int>() { 1 }
        //};
    }
}
