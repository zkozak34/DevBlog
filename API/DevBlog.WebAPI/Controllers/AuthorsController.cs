using DevBlog.Entities.Dtos.Author;
using DevBlog.Service.Services.Commands.Authors.Add;
using DevBlog.Service.Services.Commands.Authors.Delete;
using DevBlog.Service.Services.Commands.Authors.Update;
using DevBlog.Service.Services.Queries.Authors.GetAll;
using DevBlog.Service.Services.Queries.Authors.GetById;
using DevBlog.Service.Services.Queries.Authors.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.WebAPI.Controllers
{
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
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new AuthorGetByIdQuery() { Id = id });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuthorAddDto authorAddDto)
        {
            var response = await _mediator.Send(new AuthorAddCommand() { AddCommand = authorAddDto });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AuthorUpdateDto authorUpdateDto)
        {
            var response = await _mediator.Send(new AuthorUpdateCommand() { Id = id, AuthorUpdateDto = authorUpdateDto });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new AuthorDeleteCommand() { Id = id });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]AuthorLoginDto authorLoginDto)
        {
            var response = await _mediator.Send(new AuthorLoginQuery() { Email = authorLoginDto.Email, Password = authorLoginDto.Password });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
