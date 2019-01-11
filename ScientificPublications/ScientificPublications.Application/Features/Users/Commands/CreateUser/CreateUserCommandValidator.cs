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
                .ValidateEntities(n => k => k.Username == n, _data.Users)
                .NotEmpty();

            RuleFor(n => n.Password)
                .MinimumLength(8)
                //.ValidateEntities(n => k => k.Password == n, data.Users)
                .NotEmpty();
        }
    }
}
