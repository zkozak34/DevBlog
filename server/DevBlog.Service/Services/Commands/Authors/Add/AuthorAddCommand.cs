using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Authors.Add
{
    public class AuthorAddCommand : IRequest<ResponseDto<NoContent>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }
        public string Overview { get; set; }
    }
}
