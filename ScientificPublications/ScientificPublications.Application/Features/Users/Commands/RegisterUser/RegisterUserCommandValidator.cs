using FluentValidation;
using ScientificPublications.Application.Extensions;
using ScientificPublications.Application.Interfaces.Data;

namespace ScientificPublications.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator(IData data)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(n => n.Username)
                .MinimumLength(4)
                .NotEmpty()
                .None(data.Users, username => userEntity => userEntity.Username == username);

            RuleFor(n => n.Password)
                .MinimumLength(8)
                .NotEmpty();
        }
    }
}
