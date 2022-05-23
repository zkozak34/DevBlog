using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Commands.Posts.Delete
{
    public class PostDeleteCommandHandler : IRequestHandler<PostDeleteCommand, ResponseDto<NoContent>>
    {
        private readonly IPostRepository _postRepository;

        public PostDeleteCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(PostDeleteCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _postRepository.Delete(request.Id);
            if (responseFromDb)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail(500);
        }
    }
}
