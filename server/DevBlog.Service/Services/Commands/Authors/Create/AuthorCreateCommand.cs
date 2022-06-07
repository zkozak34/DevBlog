using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Authors.Create
{
    public class AuthorCreateCommand : IRequest<ResponseDto<NoContent>>
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }
        public string Overview { get; set; }
    }
}
