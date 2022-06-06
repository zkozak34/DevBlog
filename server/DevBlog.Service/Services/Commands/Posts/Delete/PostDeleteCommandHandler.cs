using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract.Post;
using MediatR;
using System.Net;

namespace DevBlog.Service.Services.Commands.Posts.Delete
{
    public class PostDeleteCommandHandler : IRequestHandler<PostDeleteCommand, ResponseDto<NoContent>>
    {
        private readonly IPostWriteRepository _postWriteRepository;

        public PostDeleteCommandHandler(IPostWriteRepository postWriteRepository)
        {
            _postWriteRepository = postWriteRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(PostDeleteCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _postWriteRepository.Delete(request.Id);
            await _postWriteRepository.SaveAsync();
            if (responseFromDb)
                return ResponseDto<NoContent>.Success(204);
            return ResponseDto<NoContent>.Fail((int)HttpStatusCode.BadRequest);
        }
    }
}
