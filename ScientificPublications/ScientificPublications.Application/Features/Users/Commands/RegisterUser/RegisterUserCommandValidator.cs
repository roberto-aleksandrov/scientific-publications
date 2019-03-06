using FluentValidation;
using ScientificPublications.Application.Common.Extensions;
using ScientificPublications.Application.Common.Interfaces.Data;

namespace ScientificPublications.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator(IData data)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(n => n.Username)
                .NotEmpty()
                .MinimumLength(4)
                .HasNoneDb(data.Users, username => userEntity => userEntity.Username == username);

            RuleFor(n => n.Password)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}
