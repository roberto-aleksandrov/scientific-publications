using FluentValidation;
using ScientificPublications.Application.Common.Extensions;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Features.Affiliations.Specifications;
using System.Linq;

namespace ScientificPublications.Application.Features.Affiliations.Commands.CreateAffiliation
{
    public class CreateAffiliationCommandValidator : AbstractValidator<CreateAffiliationCommand>
    {
        public CreateAffiliationCommandValidator(IData data)
        {
            RuleFor(n => n.ScopusId)
                .IsTrueDb(data.Affiliations,
                    (scopusId, affiliations) => !affiliations.Any(),
                    scopusId => new GetScopusAffiliationsSpecification(scopusId) { IncludeUncommited = true } )
                 .When(n => !string.IsNullOrEmpty(n.ScopusId));
        }
    }
}
