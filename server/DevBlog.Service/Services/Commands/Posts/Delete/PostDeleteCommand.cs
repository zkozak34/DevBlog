using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Posts.Delete
{
    public class PostDeleteCommand : IRequest<ResponseDto<NoContent>>
    {
        public Guid Id { get; set; }
    }
}
