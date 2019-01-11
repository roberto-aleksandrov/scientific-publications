using FluentValidation;
using ScientificPublications.Application.Extensions;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Interfaces.Hasher;
using System.Linq.Expressions;

namespace ScientificPublications.Application.Features.Users.Queries
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator(IData data, IHasher hasher)
        {
            RuleFor(n => n.Username)
                .MinimumLength(4)
                .NotEmpty();

            RuleFor(n => n.Password)
                .MinimumLength(8)
                .NotEmpty();

            RuleFor(n => n)
                .Any(data.Users, request => entity =>
                            request.Username == entity.Username 
                        && request.Password == hasher.Decrypt(entity.Password, entity.Salt));
        }
    }
}
