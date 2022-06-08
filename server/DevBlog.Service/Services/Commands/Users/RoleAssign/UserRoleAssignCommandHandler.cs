using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace DevBlog.Service.Services.Commands.Users.RoleAssign
{
    public class UserRoleAssignCommandHandler : IRequestHandler<UserRoleAssignCommand, ResponseDto<NoContent>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserRoleAssignCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ResponseDto<NoContent>> Handle(UserRoleAssignCommand request, CancellationToken cancellationToken)
        {
            AppUser appUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (appUser == null)
                return ResponseDto<NoContent>.Fail("Kullanıcı bulunamadı.", (int)HttpStatusCode.BadRequest);
            AppRole role = await _roleManager.FindByNameAsync(request.Role);
            if (role == null)
                return ResponseDto<NoContent>.Fail("Rol bulunamadı.", (int)HttpStatusCode.BadRequest);
            IdentityResult result = await _userManager.AddToRoleAsync(appUser, request.Role);
            if (result.Succeeded)
                return ResponseDto<NoContent>.Success("Kullanıcıya rol eklendi.", 200);
            return ResponseDto<NoContent>.Fail("Kullanıcıya rol eklenemedi.", (int)HttpStatusCode.InternalServerError);
        }
    }
}
