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
            SeedData.Roles.ToList().ForEach(role =>
            {
                context.Roles.Add(role);
            });

            context.SaveChanges();
        }


    }
}
