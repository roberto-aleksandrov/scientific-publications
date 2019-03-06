using FluentValidation;
using ScientificPublications.Application.Common.Attributes;

namespace ScientificPublications.Application.Features.Scopus.Commands.SyncWithScopus
{

    [Authenticated]
    public class SyncWithScopusCommandValidator : AbstractValidator<SyncWithScopusCommand>
    {
        public SyncWithScopusCommandValidator()
        {
        }
    }
}
