using AutoMapper;
using ScientificPublications.Application.Features.Publications.Automapper.Resolvers;
using ScientificPublications.Application.Features.Publications.Commands.CreatePublication;
using ScientificPublications.Domain.Entities.Publications;

namespace ScientificPublications.Application.Features.Publications.Automapper.Profiles
{
    public class PublicationRequestToEntityProfile : Profile
    {
        public PublicationRequestToEntityProfile()
        {
            CreateMap<CreatePublicationCommand, PublicationEntity>()
                .ForMember(entity => entity.AuthorsPublications, opts => opts.MapFrom<AuthorsValueResolver>());
        }
    }
}
