using DevBlog.Core.Dtos.ResponseDto;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DevBlog.Service.Services.Commands.Posts.Upload
{
    public class PostUploadCommand : IRequest<ResponseDto<bool>>
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public IFormFileCollection File { get; set; }
    }
}
