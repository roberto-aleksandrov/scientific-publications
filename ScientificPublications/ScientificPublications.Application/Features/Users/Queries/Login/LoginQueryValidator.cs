using FluentValidation;
using ScientificPublications.Application.Common.Extensions;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Interfaces.Hasher;
using ScientificPublications.Application.Features.Users.Models;

namespace ScientificPublications.Application.Features.Users.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator(IData data, IHasher hasher)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(n => n.Username)
                .MinimumLength(4)
                .NotEmpty();

            RuleFor(n => n.Password)
                .MinimumLength(8)
                .NotEmpty();

            RuleFor(n => n)
                .HasAnyDb(data.Users, request => entity =>
                        request.Username == entity.Username
                        && request.Password == hasher.Decrypt(entity.Password, entity.Salt));
        }
    }
}
