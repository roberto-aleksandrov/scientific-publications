using AutoMapper;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Application.Features.AuthorsAliases.Commands.CreateAuthorAlias;
using ScientificPublications.Application.Features.Publications.Commands.CreatePublication;
using ScientificPublications.Application.Features.Publications.Queries.GetPublications;
using ScientificPublications.Application.Features.Scopus.Commands.SyncWithScopus;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Application.Features.Users.Models;
using ScientificPublications.WebUI.Models.BindingModels.Authors;
using ScientificPublications.WebUI.Models.BindingModels.AuthorsAliases;
using ScientificPublications.WebUI.Models.BindingModels.Publications;
using ScientificPublications.WebUI.Models.BindingModels.User;

namespace ScientificPublications.WebUI.AutoMapper.Profiles
{
    public class BmToRequestProfile : Profile
    {
        public BmToRequestProfile()
        {
            CreateMap<LoginBindingModel, LoginQuery>();

            CreateMap<RegisterUserBindingModel, RegisterUserCommand>();

            CreateMap<CreatePublicationBindingModel, CreatePublicationCommand>();

            CreateMap<CreateAuthorBindingModel, CreateAuthorCommand>();

            CreateMap<CreateAuthorsAliasBindingModel, CreateAuthorAliasCommand>();

            CreateMap<GetAllPublicationsBindingModel, GetAllPublicationsQuery>();

            CreateMap<SyncWithScopusBindingModel, SyncWithScopusCommand>();
        }
    }
}
