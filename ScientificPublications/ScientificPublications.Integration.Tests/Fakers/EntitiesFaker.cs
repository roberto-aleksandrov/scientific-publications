using Bogus;
using ScientificPublications.Domain.Entities.AuthorsPublications;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;
using System;

namespace ScientificPublications.Integration.Tests.Fakers
{
    public static class EntitiesFaker
    {
        public static Faker<UserEntity> UserFaker { get; } =
                new Faker<UserEntity>()
                    .RuleFor(u => u.Password, f => "Test12345")
                    .RuleFor(u => u.Salt, f => Guid.NewGuid().ToString())
                    .RuleFor(u => u.Username, f => f.Random.String2(10));

        public static Faker<AuthorEntity> AuthorFaker { get; } =
                new Faker<AuthorEntity>()
                    .RuleFor(a => a.User, f => UserFaker.Generate())
                    .RuleFor(a => a.ScopusId, f => f.Random.Number().ToString());

        public static Faker<PublicationEntity> PublicationFaker { get; } =
                new Faker<PublicationEntity>()
                    .RuleFor(p => p.Title, f => f.Random.String2(15));

        public static Faker<AuthorPublicationEntity> AuthorPublicationFaker { get; } =
                new Faker<AuthorPublicationEntity>()
                    .RuleFor(ap => ap.Author, f => AuthorFaker.Generate())
                    .RuleFor(ap => ap.Publication, f => PublicationFaker.Generate());

    }
}
