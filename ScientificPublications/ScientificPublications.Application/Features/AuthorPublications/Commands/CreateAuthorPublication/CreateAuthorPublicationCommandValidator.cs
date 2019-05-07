using FluentValidation;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Features.Authors.Validators;
using ScientificPublications.Application.Features.Publications.Validators;

namespace ScientificPublications.Application.Features.AuthorPublications.Commands.CreateAuthorPublication
{
    public class CreateAuthorPublicationCommandValidator : AbstractValidator<CreateAuthorPublicationCommand>
    {
        public CreateAuthorPublicationCommandValidator(IData data)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(n => n.AuthorId)
                .SetValidator(new AuthorExistValidator(data));

            RuleFor(n => n.PublicationId)
                .SetValidator(new PublicationExistsValidator(data));

        }
    }
}
