using AutoMapper;
using MediatR;
using ScientificPublications.Application.Features.Publications.Models;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Domain.Entities.Publications;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Publications.Commands.CreatePublication
{
    public class CreatePublicationCommandHandler : IRequestHandler<CreatePublicationCommand, PublicationDto>
    {
        private readonly IData _data;
        private readonly IMapper _mapper;

        public CreatePublicationCommandHandler(IData data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public async Task<PublicationDto> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
        {
            var publicationEntity = _mapper.Map<PublicationEntity>(request);

            await _data.Publications.AddAsync(publicationEntity);

            var publicationDto = _mapper.Map<PublicationDto>(publicationEntity);

            return publicationDto;
        }
    }
}
