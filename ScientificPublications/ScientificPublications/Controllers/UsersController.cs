using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScientificPublications.Application.Users.Commands.CreateUser;
using ScientificPublications.WebUI.Models.BindingModels;

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
        public ActionResult<string> CreateUser([FromBody] CreateUserBindingModel createUserBm)
        {
            _mediator.Send(new CreateUserCommand { UserName = createUserBm.UserName, Password = createUserBm.Password });
            return Ok("");
        }
    }
}
