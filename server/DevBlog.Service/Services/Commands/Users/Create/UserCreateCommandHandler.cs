using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace DevBlog.Service.Services.Commands.Users.Create
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, ResponseDto<NoContent>>
    {
        private readonly UserManager<AppUser> _userManager;

        public UserCreateCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDto<NoContent>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _userManager.FindByEmailAsync(request.Email);
            if (responseFromDb != null)
                return ResponseDto<NoContent>.Fail("E-Posta adresi kullanılmaktadır.", (int)HttpStatusCode.BadRequest);
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                UserName = request.Username,
                FullName = request.FullName,
                Email = request.Email,
                ProfileImage = request.ProfileImage,
                Overview = request.Overview
            }, request.Password);
            if (result.Succeeded)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail(result.Errors.Select(i => i.Description).ToList(), (int)HttpStatusCode.BadRequest);
        }
    }
}
