using Bogus;
using ScientificPublications.Domain.Entities;
using ScientificPublications.Infrastructure;
using ScientificPublications.Integration.Tests.Fakers;
using ScientificPublications.Integration.Tests.Seed.Hooks;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Integration.Tests.Seed
{
    public class ScientificPublicationsSeeder
    {
        private readonly ScientificPublicationsContext _context;
        private readonly PreSeedHooks _preSeedHooks;

        public ScientificPublicationsSeeder(ScientificPublicationsContext context, PreSeedHooks preSeedHooks)
        {
            _context = context;
            _preSeedHooks = preSeedHooks;
        }

        private Faker<T> GetSeedData<T>()
            where T : BaseEntity
        {
            return (Faker<T>)typeof(EntitiesFaker)
                .GetProperties()
                .First(n => n.PropertyType.GetGenericArguments()[0] == typeof(T))
                .GetValue(null);
        }

        public T Seed<T>()
            where T : BaseEntity
        {
            var entity = GetSeedData<T>().Generate();

            _preSeedHooks.ExecuteHook(entity);

            _context.Set<T>().Add(entity);

            _context.SaveChanges();

            return entity;
        }

        public List<T> SeedMany<T>(int count)
            where T : BaseEntity
        {
            return Enumerable.Repeat(default(T), count)
                    .Select(n => Seed<T>())
                    .ToList();
        }
    }
}
