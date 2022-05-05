using DevBlog.Entities.Concrete;
using DevBlog.Entities.Dtos.Post;
using DevBlog.Service.Services.Commands.Posts.Add;
using DevBlog.Service.Services.Commands.Posts.Delete;
using DevBlog.Service.Services.Commands.Posts.Update;
using DevBlog.Service.Services.Queries.Posts.GetAll;
using DevBlog.Service.Services.Queries.Posts.GetById;
using DevBlog.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new PostGetAllQuery());
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(CheckExistIdFilter))]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new PostGetByIdQuery() {Id = id});
            return new ObjectResult(response) {StatusCode = response.StatusCode};
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostAddDto postAddDto)
        {
            var response = await _mediator.Send(new PostAddCommand() {PostAddDto = postAddDto});
            return new ObjectResult(response) {StatusCode = response.StatusCode};
        }

        // TODO: UPDATEDATE COLUMN DİD NOT CHANGE
        [ServiceFilter(typeof(CheckExistIdFilter))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PostUpdateDto postUpdateDto)
        {
            var response = await _mediator.Send(new PostUpdateCommand(){PostUpdateDto = postUpdateDto, Id = id});
            return new ObjectResult(response) {StatusCode = response.StatusCode};
        }

        [ServiceFilter(typeof(CheckExistIdFilter))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new PostDeleteCommand() {Id = id});
            return new ObjectResult(response) {StatusCode = response.StatusCode};
        }
    }
}
