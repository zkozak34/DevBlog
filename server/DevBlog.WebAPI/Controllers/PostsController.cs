using DevBlog.Service.Services.Commands.Posts.Add;
using DevBlog.Service.Services.Commands.Posts.Delete;
using DevBlog.Service.Services.Commands.Posts.Update;
using DevBlog.Service.Services.Commands.Posts.Upload;
using DevBlog.Service.Services.Queries.Posts.GetAll;
using DevBlog.Service.Services.Queries.Posts.GetById;
using DevBlog.WebAPI.Filters;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostsController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new PostGetAllQuery());
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new PostGetByIdQuery() { Id = id });
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostAddCommand postAddDto)
        {
            var response = await _mediator.Send(new PostAddCommand()
            {
                Overview = postAddDto.Overview,
                CategoryId = postAddDto.CategoryId,
                AuthorId = postAddDto.AuthorId,
                Content = postAddDto.Content,
                ThumbnailImage = postAddDto.ThumbnailImage,
                Title = postAddDto.Title
            });
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPut]
        public async Task<IActionResult> Update(PostUpdateCommand postUpdateDto)
        {
            var response = await _mediator.Send(new PostUpdateCommand()
            {
                Id = postUpdateDto.Id,
                Overview = postUpdateDto.Overview,
                CategoryId = postUpdateDto.CategoryId,
                AuthorId = postUpdateDto.AuthorId,
                Content = postUpdateDto.Content,
                ThumbnailImage = postUpdateDto.ThumbnailImage,
                Title = postUpdateDto.Title
            });
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new PostDeleteCommand() { Id = id });
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [FileExtensionControlFilter]
        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> Upload(Guid id)
        {
            var response = await _mediator.Send(new PostUploadCommand { PostId = id, Path = "resource\\post-images", File = Request.Form.Files.GetFile("file") });
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
