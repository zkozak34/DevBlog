using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Users.RoleAssign
{
    public class UserRoleAssignCommand : IRequest<ResponseDto<NoContent>>
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
    }
}
