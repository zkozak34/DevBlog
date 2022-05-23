using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Queries.Posts.GetAll
{
    public class PostGetAllQueryHandler : IRequestHandler<PostGetAllQuery, ResponseDto<List<Post>>>
    {
        private readonly IPostRepository _postRepository;

        public PostGetAllQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ResponseDto<List<Post>>> Handle(PostGetAllQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _postRepository.GetAll();
            if (responseFromDb.Count < 1)
                return ResponseDto<List<Post>>.Fail(500);
            return ResponseDto<List<Post>>.Success(responseFromDb, 200);
        }
    }
}
