using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;

namespace DevBlog.Service.Services.Queries.Posts.GetAll
{
    public class PostGetAllQuery : IRequest<ResponseDto<List<Post>>>
    {
    }
}
