using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;
using System;

namespace ScientificPublications.Integration.Tests.Seed
{
    public static class SeedData
    {
        public static AuthorEntity[] Authors => new AuthorEntity[]
          {
            new CathedralAuthorEntity {
                ScopusId = "12315651940213"
            },
            new NonCathedralAuthorEntity {
                ScopusId = "12315651940213432"
            }
        };

        public static UserEntity[] Users => new[]
        {
            new UserEntity {
                Username = "test",
                Password = "testPass",
                Salt = Guid.NewGuid().ToString()
            },
            new UserEntity {
                Username = "test2",
                Password = "testPass",
                Salt = Guid.NewGuid().ToString()
            }
        };

        public static PublicationEntity[] Publications => new PublicationEntity[]
        {
            new PublicationEntity {
                Title = "Random Title",
                Text = "Random Text",
            },
            new PublicationEntity {
                Title = "Random Title2",
                Text = "Random Text2"
            }
        };
    }
}
