using FluentValidation;
using ScientificPublications.Application.Extensions;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Application.Interfaces.Data;

namespace ScientificPublications.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator(IData data)
        {
            RuleFor(n => n.ScopusId)
                .HasNoneDb(data.Authors, scopusId => entity => entity.ScopusId == scopusId);

            RuleFor(n => n.RegisterUser)
                .SetValidator(new RegisterUserCommandValidator(data));
        }
    }
}
