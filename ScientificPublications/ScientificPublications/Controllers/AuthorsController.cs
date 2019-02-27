﻿using Microsoft.AspNetCore.Mvc;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Application.Features.Authors.Models;
using ScientificPublications.WebUI.Models.BindingModels.Authors;
using System.Threading.Tasks;

namespace ScientificPublications.WebUI.Controllers
{
    public class AuthorsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Create(CreateAuthorBindingModel createUserBm)
        {
            var response = await Mediator.Send(Mapper.Map<CreateAuthorCommand>(createUserBm));
            return Ok(response);
        }
    }
}
