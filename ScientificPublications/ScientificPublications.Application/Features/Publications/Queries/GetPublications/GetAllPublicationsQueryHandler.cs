using AutoMapper;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Common.Spcifications;
using ScientificPublications.Application.Features.Publications.Models;
using ScientificPublications.Domain.Entities.Publications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Publications.Queries.GetPublications
{
    public class GetAllPublicationsQueryHandler : BaseRequestHandler<GetAllPublicationsQuery, IEnumerable<PublicationDto>>
    {
        public GetAllPublicationsQueryHandler(IData data, IMapper mapper)
            : base(data, mapper) { }

        public override async Task<IEnumerable<PublicationDto>> Handle(GetAllPublicationsQuery request, CancellationToken cancellationToken)
        {
            var spec = _mapper.Map<BaseSpecification<PublicationEntity>>(request);

            var publications = await _data.Publications.ListAsync(spec);

            return _mapper.Map<IEnumerable<PublicationDto>>(publications);
        }
    }
}
