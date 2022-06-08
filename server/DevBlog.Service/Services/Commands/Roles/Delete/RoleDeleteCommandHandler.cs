using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace DevBlog.Service.Services.Commands.Roles.Delete
{
    public class RoleDeleteCommandHandler : IRequestHandler<RoleDeleteCommand, ResponseDto<NoContent>>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleDeleteCommandHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ResponseDto<NoContent>> Handle(RoleDeleteCommand request, CancellationToken cancellationToken)
        {
            AppRole appRole = await _roleManager.FindByIdAsync(request.Id);
            if (appRole != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(appRole);
                if (result.Succeeded)
                    return ResponseDto<NoContent>.Success("Silme işlemi başarılı.", 200);
                return ResponseDto<NoContent>.Fail("Rol silme işleminde bir hata oluştu.", (int)HttpStatusCode.InternalServerError);
            }
            return ResponseDto<NoContent>.Fail("Rol bulunamadı.", (int)HttpStatusCode.BadRequest);
        }
    }
}
