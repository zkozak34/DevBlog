using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Categories.Update
{
    public class CategoryUpdateCommand : IRequest<ResponseDto<NoContent>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
    }
}
