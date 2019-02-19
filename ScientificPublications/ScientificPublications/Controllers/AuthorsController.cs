using Microsoft.AspNetCore.Mvc;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Application.Features.Authors.Models;
using ScientificPublications.Application.FeaturesAggregations.UserAuthor.Commands.CreateUserAuthor;
using ScientificPublications.WebUI.Models.BindingModels.Authors;
using System.Threading.Tasks;

namespace ScientificPublications.WebUI.Controllers
{
    public class AuthorsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Create(CreateAuthorBindingModel createUserBm)
        {
            var response = await Mediator.Send(Mapper.Map<CreateUserAuthorCommand>(createUserBm));
            return Ok(response);
        }
    }
}
