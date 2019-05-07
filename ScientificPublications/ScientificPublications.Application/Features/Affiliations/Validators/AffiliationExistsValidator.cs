using FluentValidation;
using ScientificPublications.Application.Common.Constants.Validators;
using ScientificPublications.Application.Common.Extensions;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Features.Affiliations.Specifications;
using System.Linq;

namespace ScientificPublications.Application.Features.Affiliations.Validators
{
    public class AffiliationExistsValidator : AbstractValidator<int>
    {
        public AffiliationExistsValidator(IData data)
        {

            RuleFor(n => n)
            .IsTrueDb(data.Affiliations,
                (affiliationId, affiliations) => affiliations.Any(),
                (affiliationId) => new GetAffiliationSpecification(affiliationId) { Take = 1, IncludeUncommited = true },
                ErrorMessages.EntityDoesNotExists
            );
        }
    }
}
