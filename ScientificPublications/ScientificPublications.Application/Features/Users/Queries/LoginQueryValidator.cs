using FluentValidation;
using ScientificPublications.Application.Interfaces.Data;

namespace ScientificPublications.Application.Features.Users.Queries
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        private readonly IData _data;

        public LoginQueryValidator(IData data)
        {
            _data = data;
        }

        public LoginQueryValidator()
        {
            RuleFor(n => n.Username)
                .MinimumLength(4)
                .NotEmpty();

            RuleFor(n => n.Password)
                .MinimumLength(8)
                .NotEmpty();
        }
    }
}
