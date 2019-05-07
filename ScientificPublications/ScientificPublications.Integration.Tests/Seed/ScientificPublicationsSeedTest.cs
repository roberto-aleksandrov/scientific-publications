using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Domain.Enums;
using ScientificPublications.Infrastructure;
using System.Linq;

namespace ScientificPublications.Integration.Tests.Seed
{
    public static class ScientificPublicationsSeedTest
    {
        public static void Seed(ScientificPublicationsContext context)
        {
            SeedRoles(context);
        }

        private static void SeedRoles(ScientificPublicationsContext context)
        {
            context.Roles.Add(new RoleEntity { Role = Role.Author });
            
            context.SaveChanges();
        }

    }
}
