using AutoMapper;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Application.Features.Users.Queries;
using ScientificPublications.WebUI.Models.BindingModels.User;

namespace ScientificPublications.WebUI.AutoMapper.Profiles
{
    public class BmToRequestProfile : Profile
    {
        public BmToRequestProfile()
        {
            CreateMap<LoginBindingModel, LoginQuery>();
            CreateMap<RegisterUserBindingModel, RegisterUserCommand>();
        }
    }
}
