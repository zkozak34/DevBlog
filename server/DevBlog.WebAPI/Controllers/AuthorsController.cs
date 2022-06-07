﻿using DevBlog.Service.Services.Commands.Authors.Create;
using DevBlog.Service.Services.Commands.Authors.Delete;
using DevBlog.Service.Services.Commands.Authors.Login;
using DevBlog.Service.Services.Commands.Authors.Update;
using DevBlog.Service.Services.Queries.Authors.GetAll;
using DevBlog.Service.Services.Queries.Authors.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new AuthorGetAllQuery());
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new AuthorGetByIdQuery() { Id = id });
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(AuthorCreateCommand authorCreateCommand)
        {
            var response = await _mediator.Send(authorCreateCommand);
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPut]
        public async Task<IActionResult> Update(AuthorUpdateCommand authorUpdateDto)
        {
            var response = await _mediator.Send(new AuthorUpdateCommand()
            {
                Id = authorUpdateDto.Id,
                Email = authorUpdateDto.Email,
                FullName = authorUpdateDto.FullName,
                Overview = authorUpdateDto.Overview,
                ProfileImage = authorUpdateDto.ProfileImage
            });
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new AuthorDeleteCommand() { Id = id });
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(AuthorLoginCommand authorLoginCommand)
        {
            var response = await _mediator.Send(authorLoginCommand);
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
