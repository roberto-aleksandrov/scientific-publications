using FluentValidation;
using ScientificPublications.Application.Common.Attributes;
using ScientificPublications.Application.Common.Extensions;
using ScientificPublications.Application.Common.Interfaces.Data;

namespace ScientificPublications.Application.Features.Publications.Commands.CreatePublication
{

    [Authenticated]
    public class CreatePublicationValidator : AbstractValidator<CreatePublicationCommand>
    {
        public CreatePublicationValidator(IData data)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(n => n.Title)
                .NotEmpty();

            RuleFor(n => n.AuthorIds)
                .NotEmpty()
                .HasUnique(n => n);

            RuleFor(n => n.AffiliationIds)
                .NotEmpty()
                .HasUnique(n => n);
        }
    }
}
