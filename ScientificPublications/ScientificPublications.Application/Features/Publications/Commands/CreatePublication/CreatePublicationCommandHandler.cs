using AutoMapper;
using MediatR;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Features.Affiliations.Specifications;
using ScientificPublications.Application.Features.Authors.Specifications;
using ScientificPublications.Domain.Entities.AuthorsPublications;
using ScientificPublications.Domain.Entities.PublicationAffiliations;
using ScientificPublications.Domain.Entities.Publications;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Publications.Commands.CreatePublication
{
    public class CreatePublicationCommandHandler : IRequestHandler<CreatePublicationCommand, PublicationEntity>
    {
        private readonly IData _data;
        private readonly IMapper _mapper;

        public CreatePublicationCommandHandler(IData data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public async Task<PublicationEntity> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
        {
            var publicationEntity = _mapper.Map<PublicationEntity>(request);

            var authors = await _data.Authors.ListAsync(new GetAuthorsSpecification(request.AuthorIds) { IncludeUncommited = true });
            
            var authorsPublications = authors.Select(n => new AuthorPublicationEntity { Author = n });

            publicationEntity.AuthorsPublications = authorsPublications.ToList();


            if (request.AffiliationIds?.Any() != null)
            {
                var affiliations = await _data.Affiliations.ListAsync(new GetAffiliationSpecification(request.AffiliationIds) { IncludeUncommited = true });

                var publicationAffiliations = affiliations.Select(n => new PublicationAffiliationEntity { Affiliation = n });

                publicationEntity.PublicationAffiliations = publicationAffiliations.ToList();
            }
                        
            await _data.Publications.AddAsync(publicationEntity);

            return publicationEntity;
        }
    }
}
