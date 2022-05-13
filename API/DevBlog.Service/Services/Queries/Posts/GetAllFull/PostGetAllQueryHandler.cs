using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Post;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Queries.Posts.GetAllFull
{
    public class PostGetAllFullQueryHandler : IRequestHandler<PostGetAllFullQuery, ResponseDto<List<PostFullDto>>>
    {
        private readonly IPostRepository _postRepository;

        public PostGetAllFullQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ResponseDto<List<PostFullDto>>> Handle(PostGetAllFullQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _postRepository.GetAllFull();
            if (responseFromDb.Count < 1)
                return ResponseDto<List<PostFullDto>>.Fail(500);
            return ResponseDto<List<PostFullDto>>.Success(responseFromDb, 200);
        }
    }
}
