using DevBlog.Entities.Dtos.Post;
using DevBlog.Service.Services.Commands.Posts.Add;
using DevBlog.Service.Services.Commands.Posts.Delete;
using DevBlog.Service.Services.Commands.Posts.Update;
using DevBlog.Service.Services.Queries.Posts.GetAll;
using DevBlog.Service.Services.Queries.Posts.GetAllFull;
using DevBlog.Service.Services.Queries.Posts.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new PostGetAllQuery());
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [AllowAnonymous]
        [HttpGet("full")]
        public async Task<IActionResult> GetAllFull()
        {
            var response = await _mediator.Send(new PostGetAllFullQuery());
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new PostGetByIdQuery() { Id = id });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostAddDto postAddDto)
        {
            var response = await _mediator.Send(new PostAddCommand() { PostAddDto = postAddDto });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PostUpdateDto postUpdateDto)
        {
            var response = await _mediator.Send(new PostUpdateCommand() { PostUpdateDto = postUpdateDto, Id = id });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new PostDeleteCommand() { Id = id });
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
