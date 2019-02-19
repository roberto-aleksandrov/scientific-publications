﻿using Microsoft.AspNetCore.Mvc;
using ScientificPublications.Application.Features.Publications.Commands.CreatePublication;
using ScientificPublications.Application.Features.Publications.Models;
using ScientificPublications.Application.Features.Publications.Queries.GetPublications;
using ScientificPublications.WebUI.Models.BindingModels.Publications;
using System.Threading.Tasks;

namespace ScientificPublications.WebUI.Controllers
{
    public class PublicationsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PublicationDto>> GetAll([FromQuery] GetAllPublicationsBindingModel getAllPublicationsBindingModel)
        {
            var response = await Mediator.Send(Mapper.Map<GetAllPublicationsQuery>(getAllPublicationsBindingModel));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<PublicationDto>> Create([FromBody] CreatePublicationBindingModel createPublicationBm)
        {
            var response = await Mediator.Send(Mapper.Map<CreatePublicationCommand>(createPublicationBm));
            return Ok(response);
        }
    }
}
