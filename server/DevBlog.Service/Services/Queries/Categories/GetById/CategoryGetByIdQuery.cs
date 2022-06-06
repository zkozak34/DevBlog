using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Category;
using MediatR;

namespace DevBlog.Service.Services.Queries.Categories.GetById
{
    public class CategoryGetByIdQuery : IRequest<ResponseDto<CategoryDto>>
    {
        public Guid Id { get; set; }
    }
}
