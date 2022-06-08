using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace DevBlog.Service.Services.Commands.Roles.Update
{
    public class RoleUpdateCommandHandler : IRequestHandler<RoleUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleUpdateCommandHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ResponseDto<NoContent>> Handle(RoleUpdateCommand request, CancellationToken cancellationToken)
        {
            AppRole existRole = await _roleManager.FindByIdAsync(request.Id);
            if (existRole != null)
            {
                existRole.Name = request.RoleName;
                IdentityResult result = await _roleManager.UpdateAsync(existRole);
                if (result.Succeeded)
                    return ResponseDto<NoContent>.Success("Güncelleme işlemi başarılı.", 200);
                return ResponseDto<NoContent>.Fail("Rol güncelleme işleminde bir hata meydana geldi.", (int)HttpStatusCode.InternalServerError);
            }
            return ResponseDto<NoContent>.Fail("Rol bulunamadı.", (int)HttpStatusCode.BadRequest);
        }
    }
}
