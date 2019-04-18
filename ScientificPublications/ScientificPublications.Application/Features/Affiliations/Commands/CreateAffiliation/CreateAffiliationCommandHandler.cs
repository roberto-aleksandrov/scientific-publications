using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Domain.Entities.Affiliations;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Features.Affiliations.Commands.CreateAffiliation
{
    public class CreateAffiliationCommandHandler : BaseRequestHandler<CreateAffiliationCommand, AffiliationEntity>
    {
        public CreateAffiliationCommandHandler(IData data, IMapper mapper) 
            : base(data, mapper)
        {
        }

        public override async Task<AffiliationEntity> Handle(CreateAffiliationCommand request, CancellationToken cancellationToken)
        {
            var affiliationEntity = _mapper.Map<AffiliationEntity>(request);

            await _data.Affiliations.AddAsync(affiliationEntity);

            return affiliationEntity;
        }
    }
}
