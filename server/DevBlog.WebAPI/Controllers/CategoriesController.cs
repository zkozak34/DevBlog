using DevBlog.Entities.Dtos.Category;
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
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new CategoryGetByIdQuery() { Id = id });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            var response = await _mediator.Send(new CategoryAddCommand() { CategoryAddDto = categoryAddDto });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var response = await _mediator.Send(new CategoryUpdateCommand() { CategoryUpdateDto = categoryUpdateDto, Id = id });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new CategoryDeleteCommand() { Id = id });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
