using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using DevBlog.Service.Utilities.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace DevBlog.Service.Services.Commands.Users.Login
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ResponseDto<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;

        public UserLoginCommandHandler(IJWTAuthenticationManager jwtAuthenticationManager, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<ResponseDto<string>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return ResponseDto<string>.Fail("E-Posta veya Parola hatalı", (int)HttpStatusCode.BadRequest);
            var userCheckSignIn = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (userCheckSignIn.Succeeded)
            {
                var token = _jwtAuthenticationManager.Authenticate(Guid.Parse(user.Id), user.Email, user.FullName);
                return ResponseDto<string>.Success(token, 200);
            }
            return ResponseDto<string>.Fail("E-Posta veya Parola hatalı", (int)HttpStatusCode.BadRequest);
        }
    }
}
