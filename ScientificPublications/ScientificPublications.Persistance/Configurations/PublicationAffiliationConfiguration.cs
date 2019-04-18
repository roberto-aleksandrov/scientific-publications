using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificPublications.Domain.Entities.PublicationAffiliations;

namespace ScientificPublications.Persistance.Configurations
{
    public class PublicationAffiliationConfiguration : IEntityTypeConfiguration<PublicationAffiliationEntity>
    {
        public void Configure(EntityTypeBuilder<PublicationAffiliationEntity> builder)
        {
            builder.ToTable("PublicationsAffiliations");

            builder.HasKey(u => new { u.AffiliationId, u.PublicationId });

            builder.HasOne(pa => pa.Publication)
                .WithMany(p => p.PublicationAffiliations)
                .HasForeignKey(p => p.PublicationId);

            builder.HasOne(pa => pa.Affiliation)
                .WithMany(p => p.PublicationAffiliations)
                .HasForeignKey(p => p.AffiliationId);
        }
    }
}
