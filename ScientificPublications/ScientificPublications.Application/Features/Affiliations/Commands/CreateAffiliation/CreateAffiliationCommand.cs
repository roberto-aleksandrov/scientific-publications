using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Domain.Entities.Affiliations;

namespace ScientificPublications.Application.Features.Affiliations.Commands.CreateAffiliation
{
    public class CreateAffiliationCommand : BaseCommand<AffiliationEntity>
    {
        public string ScopusId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string ScopusUrl { get; set; }
    }
}
