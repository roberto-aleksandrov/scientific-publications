using FluentValidation;
using ScientificPublications.Application.Common.Extensions;
using ScientificPublications.Application.Common.Interfaces.Data;

namespace ScientificPublications.Application.Features.Authors.Commands.RegisterAuthor
{
    public class RegisterAuthorCommandValidator : AbstractValidator<RegisterAuthorCommand>
    {
        public RegisterAuthorCommandValidator(IData data)
        {
        }
    }
}
