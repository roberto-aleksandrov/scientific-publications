using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificPublications.Application.Features.Users.Commands.CreateUser;
using ScientificPublications.Application.Features.Users.Queries;
using ScientificPublications.WebUI.Models.BindingModels.User;
using System.Threading.Tasks;

namespace ScientificPublications.WebUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/register")]
        public async Task<ActionResult<string>> CreateUser([FromBody] CreateUserBindingModel createUserBm)
        {
            await _mediator.Send(new CreateUserCommand { Username = createUserBm.Username, Password = createUserBm.Password });
            return Ok("");
        }


        [HttpPost("api/login")]
        public async Task<ActionResult<LoginViewModel>> CreateUser([FromBody] LoginBindingModel loginBm)
        {
            var response = await _mediator.Send(new LoginQuery { Username = loginBm.Username, Password = loginBm.Password });
            return Ok(response);
        }


        [HttpPost("api/test")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<LoginViewModel>> Test([FromBody] LoginBindingModel loginBm)
        {
            var username = HttpContext.User.Identity.Name;
            var response = await _mediator.Send(new LoginQuery { Username = loginBm.Username, Password = loginBm.Password });
            return Ok(response);
        }
    }
}
