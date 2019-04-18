using Bogus;
using ScientificPublications.Integration.Tests.ControllersTests.PublicationsControllerTests.Contracts;

namespace ScientificPublications.Integration.Tests.Fakers
{
    public class RequestsFaker
    {
        public static Faker<CreatePublicationRequest> CreatePublicationFaker { get; } =
                new Faker<CreatePublicationRequest>()
                    .RuleFor(p => p.Description, f => f.Lorem.Sentence(5))
                    .RuleFor(p => p.Title, f => f.Lorem.Sentence(1))
                    .RuleFor(p => p.Doi, f => f.Random.Int().ToString());
    }
}
