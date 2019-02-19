using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Infrastructure.Data
{
    public class ScientificPublicationsData : IData
    {
        public ScientificPublicationsData(
            IAsyncRepository<UserEntity> users,
            IAsyncRepository<CathedralAuthorEntity> cathedralAuthors,
            IAsyncRepository<NonCathedralAuthorEntity> nonCathedralAuthors,
            IAsyncRepository<AuthorEntity> authors,
            IAsyncRepository<PublicationEntity> publications)
        {
            Users = users;
            Authors = authors;
            CathedralAuthors = cathedralAuthors;
            NonCathedralAuthors = NonCathedralAuthors;
            Publications = publications;
        }

        public IAsyncRepository<UserEntity> Users { get; }

        public IAsyncRepository<AuthorEntity> Authors { get; }

        public IAsyncRepository<CathedralAuthorEntity> CathedralAuthors { get; }

        public IAsyncRepository<NonCathedralAuthorEntity> NonCathedralAuthors { get; }

        public IAsyncRepository<PublicationEntity> Publications { get; }
    }
}
