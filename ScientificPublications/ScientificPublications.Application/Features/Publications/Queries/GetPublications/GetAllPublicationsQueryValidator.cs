using FluentValidation;
using ScientificPublications.Application.Common.Attributes;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Application.Common.Extensions;

namespace ScientificPublications.Application.Features.Publications.Queries.GetPublications
{
    [Authenticated]
    public class GetAllPublicationsQueryValidator : AbstractValidator<GetAllPublicationsQuery>
    {
        public GetAllPublicationsQueryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(n => n)
                .IsValidQuery<GetAllPublicationsQuery, PublicationEntity>();
        }
    }
}
