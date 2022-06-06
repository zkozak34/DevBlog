using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Post;
using MediatR;

namespace DevBlog.Service.Services.Queries.Posts.GetById
{
    public class PostGetByIdQuery : IRequest<ResponseDto<PostDto>>
    {
        public Guid Id { get; set; }
    }
}
