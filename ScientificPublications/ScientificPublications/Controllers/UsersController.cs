using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Application.Features.Users.Queries;
using ScientificPublications.WebUI.Models.BindingModels.User;
using System.Threading.Tasks;

namespace ScientificPublications.WebUI.Controllers
{
    public class UsersController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Register([FromBody] RegisterUserBindingModel createUserBm)
        {
            await Mediator.Send(Mapper.Map<RegisterUserCommand>(createUserBm));
            return Ok("");
        }

        [HttpPost]
        public async Task<ActionResult<LoginViewModel>> Login([FromBody] LoginBindingModel loginBm)
        {
            var response = await Mediator.Send(Mapper.Map<LoginQuery>(loginBm));
            return Ok(response);
        }
        
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public async Task<ActionResult<LoginViewModel>> Test(LoginBindingModel loginBm)
        //{   
        //    var username = HttpContext.User.Identity.Name;
        //    return Ok(username);
        //}
    }
}
