using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;

namespace DevBlog.Service.Services.Queries.Categories.GetById
{
    public class CategoryGetByIdQuery : IRequest<ResponseDto<Category>>
    {
        public int Id { get; set; }
    }
}
