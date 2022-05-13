using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Post;
using MediatR;

namespace DevBlog.Service.Services.Queries.Posts.GetAllFull
{
    public class PostGetAllFullQuery : IRequest<ResponseDto<List<PostFullDto>>>
    {
    }
}
