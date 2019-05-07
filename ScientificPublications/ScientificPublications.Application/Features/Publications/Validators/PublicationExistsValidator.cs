using FluentValidation;
using ScientificPublications.Application.Common.Constants.Validators;
using ScientificPublications.Application.Common.Extensions;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Features.Publications.Specifications;
using System.Linq;

namespace ScientificPublications.Application.Features.Publications.Validators
{
    public class PublicationExistsValidator : AbstractValidator<int>
    {
        public PublicationExistsValidator(IData data)
        {
            RuleFor(n => n)
            .IsTrueDb(data.Publications,
                (publicationId, publications) => publications.Any(),
                (publicationId) => new GetPublicationSpecification(publicationId) { Take = 1, IncludeUncommited = true },
                ErrorMessages.EntityDoesNotExists
            );
        }
    }
}
