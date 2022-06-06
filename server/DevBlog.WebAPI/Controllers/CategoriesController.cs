using DevBlog.Service.Services.Commands.Categories.Add;
using DevBlog.Service.Services.Commands.Categories.Delete;
using DevBlog.Service.Services.Commands.Categories.Update;
using DevBlog.Service.Services.Queries.Categories.GetAll;
using DevBlog.Service.Services.Queries.Categories.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new CategoryGetAllQuery());
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new CategoryGetByIdQuery() { Id = id });
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddCommand categoryAddDto)
        {
            var response = await _mediator.Send(new CategoryAddCommand() { Title = categoryAddDto.Title, Path = categoryAddDto.Path });
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateCommand categoryUpdateDto)
        {
            var response = await _mediator.Send(new CategoryUpdateCommand() { Title = categoryUpdateDto.Title, Path = categoryUpdateDto.Path, Id = categoryUpdateDto.Id });
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new CategoryDeleteCommand() { Id = id });
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
