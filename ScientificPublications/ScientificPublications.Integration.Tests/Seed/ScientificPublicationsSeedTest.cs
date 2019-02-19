using System;
using System.Collections.Generic;
using System.Linq;
using ScientificPublications.Application.Interfaces.Hasher;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Infrastructure;

namespace ScientificPublications.Integration.Tests.Seed
{
    public static class ScientificPublicationsSeedTest
    {
        public static void Seed(ScientificPublicationsContext context, IHasher hasher)
        {
            SeedUsers(context, hasher);
            SeedAuthors(context);
        }

        private static void SeedAuthors(ScientificPublicationsContext context)
        {
            var users = new Queue<UserEntity>(context.Users.ToList());

            SeedData.Authors.ToList().ForEach(author =>
            {
                var user = users.Dequeue();

                author.UserId = user.Id;

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
