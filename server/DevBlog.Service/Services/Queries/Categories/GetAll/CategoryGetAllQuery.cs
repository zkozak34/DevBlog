using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;

namespace DevBlog.Service.Services.Queries.Categories.GetAll
{
    public class CategoryGetAllQuery : IRequest<ResponseDto<List<Category>>>
    {
    }
}
