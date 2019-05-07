using FluentValidation;
using ScientificPublications.Application.Common.Constants.Validators;
using ScientificPublications.Application.Common.Extensions;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Features.Authors.Specifications;
using System.Linq;

namespace ScientificPublications.Application.Features.Authors.Validators
{
    public class AuthorExistValidator : AbstractValidator<int>
    {
        public AuthorExistValidator(IData data)
        {
            RuleFor(n => n)
            .IsTrueDb(data.Authors,
                (authorId, authors) => authors.Any(),
                (authorId) => new GetAuthorsSpecification(authorId) { Take = 1, IncludeUncommited = true },
                ErrorMessages.EntityDoesNotExists
            );
        }
    }
}
