using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Posts.Add
{
    public class PostAddCommand : IRequest<ResponseDto<NoContent>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Overview { get; set; }
        public string ThumbnailImage { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
