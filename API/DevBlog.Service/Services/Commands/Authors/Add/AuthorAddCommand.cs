using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Author;
using MediatR;

namespace DevBlog.Service.Services.Commands.Authors.Add
{
    public class AuthorAddCommand : IRequest<ResponseDto<NoContent>>
    {
        public AuthorAddDto AddCommand { get; set; }
    }
}
