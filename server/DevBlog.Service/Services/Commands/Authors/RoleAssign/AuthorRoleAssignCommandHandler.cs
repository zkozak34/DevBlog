using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DevBlog.Service.Services.Commands.Authors.RoleAssign
{
    public class AuthorRoleAssignCommandHandler : IRequestHandler<AuthorRoleAssignCommand, ResponseDto<NoContent>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AuthorRoleAssignCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ResponseDto<NoContent>> Handle(AuthorRoleAssignCommand request, CancellationToken cancellationToken)
        {
            AppUser appUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if(appUser == null)
                return ResponseDto<NoContent>.Fail("Kullanıcı bulunamadı.", (int)HttpStatusCode.BadRequest);
            AppRole role = await _roleManager.FindByNameAsync(request.Role);
            if(role == null)
                return ResponseDto<NoContent>.Fail("Rol bulunamadı.", (int)HttpStatusCode.BadRequest);
            IdentityResult result = await _userManager.AddToRoleAsync(appUser, request.Role);
            if(result.Succeeded)
                return ResponseDto<NoContent>.Success("Kullanıcıya rol eklendi.",200);
            return ResponseDto<NoContent>.Fail("Kullanıcıya rol eklenemedi.", (int)HttpStatusCode.InternalServerError);
        }
    }
}
