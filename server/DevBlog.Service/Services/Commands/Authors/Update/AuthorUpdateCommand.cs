using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Author;
using MediatR;

namespace DevBlog.Service.Services.Commands.Authors.Update
{
    public class AuthorUpdateCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
        public AuthorUpdateDto AuthorUpdateDto { get; set; }
    }
}
