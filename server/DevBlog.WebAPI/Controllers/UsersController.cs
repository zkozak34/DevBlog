using DevBlog.Service.Services.Commands.Users.Create;
using DevBlog.Service.Services.Commands.Users.Login;
using DevBlog.Service.Services.Commands.Users.RoleAssign;
using DevBlog.Service.Services.Queries.Users.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new UserGetAllQuery());
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateCommand userCreateCommand)
        {
            var response = await _mediator.Send(userCreateCommand);
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginCommand userLoginCommand)
        {
            var response = await _mediator.Send(userLoginCommand);
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RoleAssign(UserRoleAssignCommand userRoleAssignCommand)
        {
            var response = await _mediator.Send(userRoleAssignCommand);
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
