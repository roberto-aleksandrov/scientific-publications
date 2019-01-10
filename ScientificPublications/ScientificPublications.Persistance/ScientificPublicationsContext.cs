using Microsoft.EntityFrameworkCore;
using ScientificPublications.Domain.Entities;

namespace ScientificPublications.Infrastructure
{
    public class ScientificPublicationsContext : DbContext
    {
        public ScientificPublicationsContext(DbContextOptions<ScientificPublicationsContext> options) 
            : base(options) { }


        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration<User>();
        }

    }
}
