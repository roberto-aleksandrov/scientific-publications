using AutoMapper;
using ScientificPublications.Application.Features.Publications.Models;
using ScientificPublications.Domain.Entities.Publications;

namespace ScientificPublications.Application.Features.Publications.Automapper.Profiles
{
    public class PublicationEntityToDtoProfile : Profile
    {
        public PublicationEntityToDtoProfile()
        {
            CreateMap<PublicationEntity, PublicationDto>();
        }
    }
}
