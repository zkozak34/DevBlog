using DevBlog.Service.Services.Commands.Users.Create;
using DevBlog.Service.Services.Commands.Users.Login;
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

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    var response = await _mediator.Send(new UserGetByIdQuery() { Id = id });
        //    if (response.StatusCode == 204)
        //        return NoContent();
        //    return new ObjectResult(response) { StatusCode = response.StatusCode };
        //}

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateCommand userCreateCommand)
        {
            var response = await _mediator.Send(userCreateCommand);
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        //[HttpPut]
        //public async Task<IActionResult> Update(UserUpdateCommand userUpdateCommand)
        //{
        //    var response = await _mediator.Send(new UserUpdateCommand()
        //    {
        //        Id = userUpdateCommand.Id,
        //        Email = userUpdateCommand.Email,
        //        FullName = userUpdateCommand.FullName,
        //        Overview = userUpdateCommand.Overview,
        //        ProfileImage = userUpdateCommand.ProfileImage
        //    });
        //    if (response.StatusCode == 204)
        //        return NoContent();
        //    return new ObjectResult(response) { StatusCode = response.StatusCode };
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var response = await _mediator.Send(new UserDeleteCommand() { Id = id });
        //    if (response.StatusCode == 204)
        //        return NoContent();
        //    return new ObjectResult(response) { StatusCode = response.StatusCode };
        //}

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginCommand userLoginCommand)
        {
            var response = await _mediator.Send(userLoginCommand);
            if (response.StatusCode == 204)
                return NoContent();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
