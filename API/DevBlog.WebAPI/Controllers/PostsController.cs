using DevBlog.Service.Services.Queries.Posts.GetAll;
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
    }
}
