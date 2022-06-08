using DevBlog.Entities.Concrete;
using DevBlog.Service.Services.Commands.Roles.Create;
using DevBlog.Service.Services.Commands.Roles.Delete;
using DevBlog.Service.Services.Commands.Roles.Update;
using DevBlog.Service.Services.Queries.Roles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new RoleGetAllQuery());
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateCommand roleCreateCommand)
        {
            var response = await _mediator.Send(roleCreateCommand);
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleUpdateCommand roleUpdateCommand)
        {
            var response = await _mediator.Send(roleUpdateCommand);
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _mediator.Send(new RoleDeleteCommand(){Id = id});
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
