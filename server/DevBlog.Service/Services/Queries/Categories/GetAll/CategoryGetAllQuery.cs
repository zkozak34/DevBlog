using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Category;
using MediatR;

namespace DevBlog.Service.Services.Queries.Categories.GetAll
{
    public class CategoryGetAllQuery : IRequest<ResponseDto<IEnumerable<CategoryDto>>>
    {
    }
}
