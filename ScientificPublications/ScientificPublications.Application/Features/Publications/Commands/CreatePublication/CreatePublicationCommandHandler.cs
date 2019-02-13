using AutoMapper;
using MediatR;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Spcifications.Users;
using ScientificPublications.Domain.Entities.Publications;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Publications.Commands.CreatePublication
{
    public class CreatePublicationCommandHandler : IRequestHandler<CreatePublicationCommand, CreatePublicationViewModel>
    {
        private readonly IData _data;
        private readonly IMapper _mapper;

        public CreatePublicationCommandHandler(IData data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public async Task<CreatePublicationViewModel> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _data.Publications.AddAsync(_mapper.Map<PublicationEntity>(request));        
            var vm = _mapper.Map<CreatePublicationViewModel>(entity);

            return vm;
        }
    }
}
