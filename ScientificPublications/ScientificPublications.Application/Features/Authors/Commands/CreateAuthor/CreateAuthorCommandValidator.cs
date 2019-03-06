using FluentValidation;
using ScientificPublications.Application.Common.Extensions;
using ScientificPublications.Application.Common.Interfaces.Data;

namespace ScientificPublications.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator(IData data)
        {
            RuleFor(n => n.ScopusId)
                .HasNoneDb(data.Authors, scopusId => entity => entity.ScopusId == scopusId);
        }
    }
}
