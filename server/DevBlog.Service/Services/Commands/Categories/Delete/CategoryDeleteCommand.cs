using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Categories.Delete
{
    public class CategoryDeleteCommand : IRequest<ResponseDto<NoContent>>
    {
        public Guid Id { get; set; }
    }
}
