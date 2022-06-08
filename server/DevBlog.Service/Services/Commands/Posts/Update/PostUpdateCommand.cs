using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Posts.Update
{
    public class PostUpdateCommand : IRequest<ResponseDto<NoContent>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string Overview { get; set; }

        public string ThumbnailImage { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }
    }
}
