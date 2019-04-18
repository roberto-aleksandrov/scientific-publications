using AutoMapper;
using ScientificPublications.Application.Common.Models.Dtos;
using ScientificPublications.Application.Features.Affiliations.Commands.CreateAffiliation;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Application.Features.Publications.Commands.CreatePublication;
using System.Collections.Generic;

namespace ScientificPublications.Application.Features.Scopus.AutoMapper.Profiles
{
    public class ScopusDtoToRequestProfile : Profile
    {
        public ScopusDtoToRequestProfile()
        {
            CreateMap<ScopusPublicationDto, CreatePublicationCommand>();

            CreateMap<ScopusAffiliationDto, CreateAffiliationCommand>();
            
            CreateMap<ScopusAuthorDto, CreateAuthorCommand>()
                .ForMember(req => req.Aliases, opt => opt.MapFrom(dto => new List<string> { dto.Name }));
        }
    }
}
