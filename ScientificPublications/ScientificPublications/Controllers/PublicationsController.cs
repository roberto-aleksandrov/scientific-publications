using Microsoft.AspNetCore.Mvc;
using ScientificPublications.Application.Features.Publications.Commands.CreatePublication;
using ScientificPublications.WebUI.Models.BindingModels.Publications;
using System.Threading.Tasks;

namespace ScientificPublications.WebUI.Controllers
{
    public class PublicationsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<CreatePublicationViewModel>> Create([FromBody] CreatePublicationBindingModel createPublicationBm)
        {
            var response = await Mediator.Send(Mapper.Map<CreatePublicationCommand>(createPublicationBm));
            return Ok(response);
        }
    }
}
