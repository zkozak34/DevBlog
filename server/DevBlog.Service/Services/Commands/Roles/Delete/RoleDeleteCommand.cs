using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Roles.Delete
{
    public class RoleDeleteCommand : IRequest<ResponseDto<NoContent>>
    {
        public string Id { get; set; }
    }
}
