using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Domain.Entities.AuthorsPublications;

namespace ScientificPublications.Application.Features.AuthorPublications.Commands.CreateAuthorPublication
{
    public class CreateAuthorPublicationCommand : BaseCommand<AuthorPublicationEntity>
    {
        public int AuthorId { get; set; }

        public int PublicationId { get; set; }
    }
}
