using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace DevBlog.Service.Services.Commands.Roles.Create
{
    public class RoleCreateCommandHandler : IRequestHandler<RoleCreateCommand, ResponseDto<NoContent>>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleCreateCommandHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ResponseDto<NoContent>> Handle(RoleCreateCommand request, CancellationToken cancellationToken)
        {
            AppRole existRole = await _roleManager.FindByNameAsync(request.RoleName);
            if (existRole == null)
            {
                IdentityResult result = await _roleManager.CreateAsync(new AppRole() { Name = request.RoleName });
                if (result.Succeeded)
                    return ResponseDto<NoContent>.Success("Rol ekleme işlemi başarılı.", 200);
                return ResponseDto<NoContent>.Fail("Rol ekleme işleminde bir hata meydana geldi.", (int)HttpStatusCode.InternalServerError);
            }
            return ResponseDto<NoContent>.Fail("Rol zaten mevcut.", (int)HttpStatusCode.BadRequest);
        }
    }
}
