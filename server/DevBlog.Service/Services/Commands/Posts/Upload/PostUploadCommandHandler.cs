using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract.Post;
using DevBlog.Service.Utilities.Storage.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace DevBlog.Service.Services.Commands.Posts.Upload
{
    public class PostUploadCommandHandler : IRequestHandler<PostUploadCommand, ResponseDto<string>>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStorageService _storageService;
        private readonly IPostWriteRepository _postWriteRepository;
        private readonly IPostReadRepository _postReadRepository;

        public PostUploadCommandHandler(IWebHostEnvironment webHostEnvironment, IStorageService storageService, IPostWriteRepository postWriteRepository, IPostReadRepository postReadRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _storageService = storageService;
            _postWriteRepository = postWriteRepository;
            _postReadRepository = postReadRepository;
        }

        public async Task<ResponseDto<string>> Handle(PostUploadCommand request, CancellationToken cancellationToken)
        {
            var post = await _postReadRepository.GetByIdAsync(request.PostId);
            var newFileName = await _storageService.UploadAsync(request.Path, request.File, post.ThumbnailImage);
            if (newFileName != null)
            {
                post.ThumbnailImage = newFileName;
                await _postWriteRepository.SaveAsync();
                return ResponseDto<string>.Success(newFileName, 200);
            }
            return ResponseDto<string>.Fail((int)HttpStatusCode.BadRequest);
        }
    }
}
