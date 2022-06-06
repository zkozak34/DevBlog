using DevBlog.Core.Dtos.ResponseDto;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DevBlog.Service.Services.Commands.Posts.Upload
{
    public class PostUploadCommand : IRequest<ResponseDto<string>>
    {
        public Guid PostId { get; set; }
        public string Path { get; set; }
        public IFormFile File { get; set; }
    }
}
