using FluentValidation;
using ScientificPublications.Application.Common.Extensions;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Features.Authors.Specifications;
using System.Linq;

namespace ScientificPublications.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator(IData data)
        {
            RuleFor(n => n.ScopusId)
                .IsTrueDb(data.Authors,
                    (scopusId, authors) => !authors.Any(),
                    scopusId => new GetScopusAuthorsSpecification(scopusId))
                .When(n => !string.IsNullOrEmpty(n.ScopusId));
        }
    }
}
