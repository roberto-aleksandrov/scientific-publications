using FluentValidation;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Features.Affiliations.Validators;
using ScientificPublications.Application.Features.Publications.Validators;

namespace ScientificPublications.Application.Features.PublicationAffiliations.Commands.CreatePublicationAffiliation
{
    public class CreatePublicationAffiliationCommandValidator : AbstractValidator<CreatePublicationAffiliationCommand>
    {
        public CreatePublicationAffiliationCommandValidator(IData data)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(n => n.PublicationId)
                .SetValidator(new AffiliationExistsValidator(data));

            RuleFor(n => n.PublicationId)
                .SetValidator(new PublicationExistsValidator(data));
        }
    }
}
