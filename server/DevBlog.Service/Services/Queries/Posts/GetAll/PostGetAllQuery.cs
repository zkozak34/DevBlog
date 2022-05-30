using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using DevBlog.Entities.Dtos.Post;
using MediatR;

namespace DevBlog.Service.Services.Queries.Posts.GetAll
{
    public class PostGetAllQuery : IRequest<ResponseDto<List<PostFullDto>>>
    {
    }
}
