using FluentValidation;
using ScientificPublications.Application.Attributes;
using ScientificPublications.Application.Extensions;
using ScientificPublications.Application.Features.Publications.Models;
using ScientificPublications.Application.Interfaces.Data;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Application.Features.Publications.Commands.CreatePublication
{

    [Authenticated]
    public class CreatePublicationValidator : AbstractValidator<CreatePublicationCommand>
    {
        public CreatePublicationValidator(IData data)
        {
            RuleFor(n => n.Text)
                .NotEmpty();


            RuleFor(n => n.AuthorsPublications)
                .HasUnique(n => n.AuthorId);

            //RuleFor(n => n.UsersPublications)
            //    .None(data.Users, authorsPublications => entity => !authorsPublications.Any(n => n.AuthorId == entity.Id));
        }
    }
}
