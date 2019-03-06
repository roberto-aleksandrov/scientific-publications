using AutoMapper;
using MediatR;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Domain.Entities.Publications;
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

            return await _data.Publications.AddAsync(publicationEntity);
        }
    }
}
