using Microsoft.AspNetCore.Mvc;
using ScientificPublications.Application.Features.Authors.Commands.RegisterAuthor;
using ScientificPublications.WebUI.Models.BindingModels.Authors;
using System.Threading.Tasks;

namespace ScientificPublications.WebUI.Controllers
{
    public class AuthorsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(RegisterAuthorBindingModel createUserBm)
        {
            var response = await Mediator.Send(Mapper.Map<RegisterAuthorCommand>(createUserBm));
            return Ok(response);
        }
    }
}
