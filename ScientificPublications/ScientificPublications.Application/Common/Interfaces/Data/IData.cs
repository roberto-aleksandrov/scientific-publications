using ScientificPublications.Domain.Entities;
using ScientificPublications.Domain.Entities.Affiliations;
using ScientificPublications.Domain.Entities.AuthorsPublications;
using ScientificPublications.Domain.Entities.PublicationAffiliations;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Common.Interfaces.Data
{
    public interface IData
    {
        IAsyncRepository<UserEntity> Users { get; }

        IAsyncRepository<PublicationEntity> Publications { get; }

        IAsyncRepository<AuthorEntity> Authors { get; }

        IAsyncRepository<CathedralAuthorEntity> CathedralAuthors{ get; }

        IAsyncRepository<NonCathedralAuthorEntity> NonCathedralAuthors{ get; }

        IAsyncRepository<RoleEntity> Roles { get; }

        IAsyncRepository<UserRoleEntity> UserRoles { get; }

        IAsyncRepository<AffiliationEntity> Affiliations { get; }

        IAsyncRepository<PublicationAffiliationEntity> PublicationAffiliations { get; }

        IAsyncRepository<AuthorPublicationEntity> AuthorPublications { get; }

        IAsyncRepository<TEntity> Repository<TEntity>()
            where TEntity : BaseEntity;

        Task<int> SaveChangesAsync();
    }
}
