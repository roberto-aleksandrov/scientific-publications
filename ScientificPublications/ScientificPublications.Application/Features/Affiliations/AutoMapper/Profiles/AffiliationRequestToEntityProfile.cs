using AutoMapper;
using ScientificPublications.Application.Features.Affiliations.Commands.CreateAffiliation;
using ScientificPublications.Domain.Entities.Affiliations;

namespace ScientificPublications.Application.Features.Affiliations.AutoMapper.Profiles
{
    public class AffiliationRequestToEntityProfile : Profile
    {
        public AffiliationRequestToEntityProfile()
        {
            CreateMap<CreateAffiliationCommand, AffiliationEntity>();
        }
    }
}
