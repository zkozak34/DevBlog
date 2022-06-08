using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Users.Login
{
    public class UserLoginCommand : IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
