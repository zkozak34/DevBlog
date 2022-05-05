using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Post;
using MediatR;

namespace DevBlog.Service.Services.Commands.Posts.Add
{
    public class PostAddCommand : IRequest<ResponseDto<NoContent>>
    {
        public PostAddDto PostAddDto { get; set; }
    }
}
