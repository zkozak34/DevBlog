using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Categories.Add
{
    public class CategoryAddCommand : IRequest<ResponseDto<NoContent>>
    {
        public string Title { get; set; }
        public string Path { get; set; }
    }
}
