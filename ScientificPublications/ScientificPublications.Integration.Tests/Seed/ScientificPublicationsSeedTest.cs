using System;
using System.Collections.Generic;
using System.Linq;
using ScientificPublications.Application.Interfaces.Hasher;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Domain.Enums;
using ScientificPublications.Infrastructure;

namespace ScientificPublications.Integration.Tests.Seed
{
    public static class ScientificPublicationsSeedTest
    {
        public static void Seed(ScientificPublicationsContext context, IHasher hasher)
        {
            SeedUsers(context, hasher);
            SeedRoles(context);
            SeedAuthors(context);
        }

        private static void SeedRoles(ScientificPublicationsContext context)
        {
            SeedData.Roles.ToList().ForEach(role =>
            {
                context.Roles.Add(role);
            });

            context.SaveChanges();
        }

        private static void SeedAuthors(ScientificPublicationsContext context)
        {
            var users = new Queue<UserEntity>(context.Users.ToList());
            var role = context.Roles.FirstOrDefault(n => n.Role == Role.Author);

            SeedData.Authors.ToList().ForEach(author =>
            {
                var user = users.Dequeue();

                author.UserId = user.Id;
                //author.User.UserRoles.Add(new UserRoleEntity { Role = role });            

                context.Authors.Add(author);
            });
            
            context.SaveChanges();
        }

        private static void SeedUsers(ScientificPublicationsContext context, IHasher hasher)
        {
            SeedData.Users.ToList().ForEach(user =>
            {
                user.Password = hasher.Create(user.Password, user.Salt);
                context.Users.Add(user);
            });
            context.SaveChanges();
        }

    }
}
