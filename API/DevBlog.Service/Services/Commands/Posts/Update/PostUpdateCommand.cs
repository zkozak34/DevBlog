using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Post;
using MediatR;

namespace DevBlog.Service.Services.Commands.Posts.Update
{
    public class PostUpdateCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
        public PostUpdateDto PostUpdateDto { get; set; }
    }
}
