using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScientificPublications.Domain.Entities;
using ScientificPublications.Domain.Entities.AuthorsPublications;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Infrastructure
{
    public class ScientificPublicationsContext : DbContext
    {
        public ScientificPublicationsContext(DbContextOptions<ScientificPublicationsContext> options) 
            : base(options) { }


        public DbSet<UserEntity> Users { get; set; }

        public DbSet<AuthorEntity> Authors { get; set; }

        public DbSet<NonCathedralAuthorEntity> NonCathedralAuthors { get; set; }

        public DbSet<CathedralAuthorEntity> CathedralAuthors { get; set; }

        public DbSet<PublicationEntity> Publications { get; set; }

        public DbSet<UserRoleEntity> UsersRoles { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ScientificPublicationsContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var createdEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            createdEntities.ForEach(e =>
            {
                var now = DateTime.Now;
                e.Property(nameof(BaseEntity.CreationDate)).CurrentValue = now;
                e.Property(nameof(BaseEntity.UpdateDate)).CurrentValue = now;
            });

            var editedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            editedEntities.ForEach(e =>
            {
                e.Property(nameof(BaseEntity.UpdateDate)).CurrentValue = DateTime.Now;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
