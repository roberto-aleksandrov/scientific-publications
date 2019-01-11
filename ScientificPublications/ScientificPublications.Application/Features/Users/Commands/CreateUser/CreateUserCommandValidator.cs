using FluentValidation;
using ScientificPublications.Application.Extensions;
using ScientificPublications.Application.Interfaces.Data;

namespace ScientificPublications.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IData _data;

        public CreateUserCommandValidator(IData data)
        {
            _data = data;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(n => n.Username)
                .MinimumLength(4)
                .NotEmpty()
                .None(_data.Users, username => userEntity => userEntity.Username == username);

            RuleFor(n => n.Password)
                .MinimumLength(8)
                .NotEmpty();
        }
    }
}
