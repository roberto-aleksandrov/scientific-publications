using AutoMapper;
using ScientificPublications.Application.Features.Publications.Commands.CreatePublication;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.AutoMapper
{
    public class EntityToViewModelProfile : Profile
    {
        public EntityToViewModelProfile()
        {
            CreateMap<UserEntity, RegisterUserViewModel>();

            CreateMap<PublicationEntity, CreatePublicationViewModel>();
        }
    }
}
