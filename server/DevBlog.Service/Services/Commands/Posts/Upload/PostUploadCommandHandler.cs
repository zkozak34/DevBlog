using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Post;
using DevBlog.Repository.Abstract;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace DevBlog.Service.Services.Commands.Posts.Upload
{
    public class PostUploadCommandHandler : IRequestHandler<PostUploadCommand, ResponseDto<bool>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostUploadCommandHandler(IPostRepository postRepository, IWebHostEnvironment webHostEnvironment)
        {
            _postRepository = postRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseDto<bool>> Handle(PostUploadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var post = await _postRepository.GetById(request.Id);

                string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, request.Path);
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);
                
                string fileName = request.File.GetFile("file").FileName;
                Random r = new Random();
                string newFileName = $"{r.NextInt64()}{Path.GetExtension(fileName)}";
                string fullPath = Path.Combine(uploadPath, newFileName);
                
                await using var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite,
                    FileShare.ReadWrite, 1024 * 1024, useAsync: true);
                var existsImage = Path.Combine(uploadPath, post.ThumbnailImage);
                if(File.Exists(existsImage)) File.Delete(Path.Combine(uploadPath, post.ThumbnailImage));
                await fileStream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                bool updatePostImageInDb = await _postRepository.Update(request.Id, new PostUpdateDto()
                {
                    Title = post.Title,
                    Overview = post.Overview,
                    ThumbnailImage = newFileName,
                    AuthorId = post.AuthorId,
                    CategoryId = post.CategoryId,
                    Content = post.Content
                });
                if(!updatePostImageInDb) return ResponseDto<bool>.Fail("Image could not write on database", 500);
                return ResponseDto<bool>.Success(200);
            }
            catch (Exception e)
            {
                return ResponseDto<bool>.Fail(500);
            }
        }
    }
}
