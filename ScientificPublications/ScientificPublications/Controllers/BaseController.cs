using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ScientificPublications.Infrastructure.Mediator.Interfaces;

namespace ScientificPublications.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        private IPersistableMediator _mediator;
        private IMapper _mapper;

        protected IPersistableMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IPersistableMediator>());

        protected IMapper Mapper => _mapper ?? (_mapper = HttpContext.RequestServices.GetService<IMapper>());
    }
}
