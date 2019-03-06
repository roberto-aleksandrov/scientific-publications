using Microsoft.AspNetCore.Mvc;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Application.Features.Users.Models;
using ScientificPublications.Application.Features.Users.Queries.Login;
using ScientificPublications.WebUI.Models.BindingModels.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScientificPublications.WebUI.Controllers
{
    public class UsersController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<List<int>>> Register(RegisterUserBindingModel createUserBm)
        {
            return await Mediator.Send(Mapper.Map<RegisterUserCommand>(createUserBm));
        }

        [HttpPost]
        public async Task<ActionResult<LoginDto>> Login([FromBody] LoginBindingModel loginBm)
        {
            var response = await Mediator.Send(Mapper.Map<LoginQuery>(loginBm));
            return Ok(response);
        }

    }
}
