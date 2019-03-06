using AutoMapper;
using ScientificPublications.Application.Common.Models.Dtos;
using ScientificPublications.Application.Features.Publications.Commands.CreatePublication;

namespace ScientificPublications.Application.Features.Scopus.AutoMapper.Profiles
{
    public class ScopusDtoToCommandProfile : Profile
    {
        public ScopusDtoToCommandProfile()
        {
            CreateMap<ScopusAuthorPublicationDto, CreatePublicationCommand>();
        }
    }
}
