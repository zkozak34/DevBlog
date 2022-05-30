using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using DevBlog.Entities.Dtos.Post;
using DevBlog.Repository.Abstract;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace DevBlog.Service.Services.Queries.Posts.GetAll
{
    public class PostGetAllQueryHandler : IRequestHandler<PostGetAllQuery, ResponseDto<List<PostFullDto>>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostGetAllQueryHandler(IPostRepository postRepository, IWebHostEnvironment webHostEnvironment)
        {
            _postRepository = postRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseDto<List<PostFullDto>>> Handle(PostGetAllQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _postRepository.GetAllFull();
            foreach (var post in responseFromDb)
            {
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath,"resource\\post-images", post.ThumbnailImage);
                post.ThumbnailImage = Convert.ToBase64String(await File.ReadAllBytesAsync(imagePath));
            }
            if (responseFromDb.Count < 1)
                return ResponseDto<List<PostFullDto>>.Fail(500);
            return ResponseDto<List<PostFullDto>>.Success(responseFromDb, 200);
        }
    }
}
