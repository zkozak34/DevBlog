using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Users.Delete
{
    public class UserDeleteCommand : IRequest<ResponseDto<NoContent>>
    {
        public Guid Id { get; set; }
    }
}
