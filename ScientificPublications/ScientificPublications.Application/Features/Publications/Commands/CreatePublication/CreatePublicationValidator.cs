using FluentValidation;
using ScientificPublications.Application.Common.Attributes;
using ScientificPublications.Application.Common.Extensions;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Spcifications;
using ScientificPublications.Application.Features.Authors.Specifications;
using ScientificPublications.Domain.Entities.Users;
using System.Linq;

namespace ScientificPublications.Application.Features.Publications.Commands.CreatePublication
{

    [Authenticated]
    public class CreatePublicationValidator : AbstractValidator<CreatePublicationCommand>
    {
        public CreatePublicationValidator(IData data)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(n => n.Title)
                .NotEmpty();

            //RuleFor(n => n.Text)
            //    .NotEmpty();

            RuleFor(n => n.AuthorIds)
                .NotEmpty()
                .HasUnique(n => n)
                .IsTrueDb(data.Authors,
                    (authorIds, authors) => !authorIds.Any(id => authors.All(author => id != author.Id)),
                    (authorIds) => new GetAuthorsSpecification(authorIds) { IncludeUncommited = true}
                );
        }
    }
}
