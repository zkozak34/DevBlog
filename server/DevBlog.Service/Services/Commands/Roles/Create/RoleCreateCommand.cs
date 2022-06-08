using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Roles.Create
{
    public class RoleCreateCommand : IRequest<ResponseDto<NoContent>>
    {
        public string RoleName { get; set; }
    }
}
