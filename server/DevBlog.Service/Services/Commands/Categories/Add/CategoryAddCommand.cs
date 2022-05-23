using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Category;
using MediatR;

namespace DevBlog.Service.Services.Commands.Categories.Add
{
    public class CategoryAddCommand : IRequest<ResponseDto<NoContent>>
    {
        public CategoryAddDto CategoryAddDto { get; set; }
    }
}
