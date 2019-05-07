using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Features.Authors.Specifications;
using ScientificPublications.Application.Features.Publications.Specifications;
using ScientificPublications.Domain.Entities.AuthorsPublications;

namespace ScientificPublications.Application.Features.AuthorPublications.Commands.CreateAuthorPublication
{
    public class CreateAuthorPublicationCommandHandler : BaseRequestHandler<CreateAuthorPublicationCommand, AuthorPublicationEntity>
    {
        public CreateAuthorPublicationCommandHandler(IData data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public override async Task<AuthorPublicationEntity> Handle(CreateAuthorPublicationCommand request, CancellationToken cancellationToken)
        {
            var author = await _data.Authors.SingleAsync(new GetAuthorsSpecification(request.AuthorId) { IncludeUncommited = true });

            var publication = await _data.Publications.SingleAsync(new GetPublicationSpecification(request.PublicationId) { IncludeUncommited = true });

            var authorPublication = new AuthorPublicationEntity
            {
                Author = author,
                Publication = publication
            };

            authorPublication = await _data.AuthorPublications.AddAsync(authorPublication);

            return authorPublication;
        }
    }
}
