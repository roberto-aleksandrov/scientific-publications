using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScientificPublications.Application.Features.Users.Commands.CreateUser;
using ScientificPublications.WebUI.Models.BindingModels;
using System;
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
            await _mediator.Send(new CreateUserCommand { Username = createUserBm.UserName, Password = createUserBm.Password });
            return Ok("");
        }
    }
}
