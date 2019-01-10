using FluentValidation;

namespace ScientificPublications.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(n => n.UserName)
                .MinimumLength(4)
                .NotEmpty();

            RuleFor(n => n.UserName)
                .MinimumLength(8)
                .NotEmpty();
        }
    }
}
