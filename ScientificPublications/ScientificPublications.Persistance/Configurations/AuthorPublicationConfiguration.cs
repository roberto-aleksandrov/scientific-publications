using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificPublications.Domain.Entities;
using ScientificPublications.Domain.Entities.AuthorsPublications;

namespace ScientificPublications.Persistance.Configurations
{
    public class AuthorPublicationConfiguration : IEntityTypeConfiguration<AuthorPublicationEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorPublicationEntity> builder)
        {
            builder.ToTable(nameof(AuthorPublicationEntity.Publication.AuthorsPublications));

            builder.HasKey(u => new { u.AuthorId, u.PublicationId});
            
            builder.HasOne(up => up.Publication)
                .WithMany(p => p.AuthorsPublications)
                .HasForeignKey(p => p.PublicationId);

            builder.HasOne(up => up.Author)
                .WithMany(u => u.AuthorsPublications)
                .HasForeignKey(u => u.AuthorId);
        }
    }
}
