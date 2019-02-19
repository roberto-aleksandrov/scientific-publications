using FluentValidation;
using ScientificPublications.Application.Attributes;
using ScientificPublications.Application.Extensions;
using ScientificPublications.Domain.Entities.Publications;

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
