using DevBlog.Entities.Dtos.Post;
using DevBlog.Service.Services.Commands.Posts.Add;
using DevBlog.Service.Services.Commands.Posts.Delete;
using DevBlog.Service.Services.Commands.Posts.Update;
using DevBlog.Service.Services.Queries.Posts.GetAll;
using DevBlog.Service.Services.Queries.Posts.GetAllFull;
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

        [FileExtensionControlFilter]
        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> Upload(int id)
        {
            var post = await _mediator.Send(new PostGetByIdQuery() { Id = id });
            string fileName = Request.Form.Files.GetFile("file").FileName;
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/post-images");
            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
            
            Random r = new Random();
            string newFileName = $"{r.NextInt64()}{Path.GetExtension(fileName)}";
            string fullPath = Path.Combine(uploadPath, newFileName);

            await using var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, 1024 * 1024, useAsync: false);
            if(Directory.Exists(Path.Combine(uploadPath,post.Data.ThumbnailImage))) Directory.Delete(Path.Combine(uploadPath, post.Data.ThumbnailImage));
            await fileStream.CopyToAsync(fileStream); 
            await fileStream.FlushAsync(); 
            await _mediator.Send(new PostUpdateCommand() {Id = id, PostUpdateDto = new PostUpdateDto() 
                {
                    Title = post.Data.Title,
                    CategoryId = post.Data.CategoryId,
                    AuthorId= post.Data.AuthorId,
                    Content= post.Data.Content,
                    Overview = post.Data.Overview,
                    ThumbnailImage = newFileName.ToString()
                }
            });
        
            return Ok(fileName);
        }
    }
}
