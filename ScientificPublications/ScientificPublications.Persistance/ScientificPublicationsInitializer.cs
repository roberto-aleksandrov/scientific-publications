using System;
using System.Collections.Generic;
using System.Linq;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Domain.Enums;
using ScientificPublications.Infrastructure;

namespace ScientificPublications.Persistance
{
    public class ScientificPublicationsInitializer
    {
        private readonly Dictionary<int, RoleEntity> _roles = new Dictionary<int, RoleEntity>();

        public static void Initialize(ScientificPublicationsContext context)
        {
            new ScientificPublicationsInitializer().Seed(context);
        }

        public void Seed(ScientificPublicationsContext context)
        {
            SeedRoles(context);
        }

        private void SeedRoles(ScientificPublicationsContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            context.Roles.Add(new RoleEntity { Role = Role.Author });

            context.SaveChanges();
        }
    }
}
