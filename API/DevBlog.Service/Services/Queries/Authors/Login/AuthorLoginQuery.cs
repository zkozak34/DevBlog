using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Author;
using MediatR;

namespace DevBlog.Service.Services.Queries.Authors.Login
{
    public class AuthorLoginQuery : IRequest<ResponseDto<AuthorDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
