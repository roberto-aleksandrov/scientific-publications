using AutoMapper;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Application.FeaturesAggregations.UserAuthor.Commands.CreateUserAuthor;

namespace ScientificPublications.Application.FeaturesAggregations.UserAuthor.Automapper.Profiles
{
    public class UserAuthorCommandToCommandProfile : Profile
    {
        public UserAuthorCommandToCommandProfile()
        {
            CreateMap<CreateUserAuthorCommand, RegisterUserCommand>();

            CreateMap<CreateUserAuthorCommand, CreateAuthorCommand>();
        }
    }
}
