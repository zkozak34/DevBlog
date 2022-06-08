using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Roles.Update
{
    public class RoleUpdateCommand : IRequest<ResponseDto<NoContent>>
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
    }
}
