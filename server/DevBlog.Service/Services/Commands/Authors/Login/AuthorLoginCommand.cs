using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Authors.Login
{
    public class AuthorLoginCommand : IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
