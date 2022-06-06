using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract.Post;
using MediatR;

namespace DevBlog.Service.Services.Commands.Posts.Update
{
    public class PostUpdateCommandHandler : IRequestHandler<PostUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly IPostWriteRepository _postWriteRepository;
        private readonly IPostReadRepository _postReadRepository;

        public PostUpdateCommandHandler(IPostWriteRepository postWriteRepository, IPostReadRepository postReadRepository)
        {
            _postWriteRepository = postWriteRepository;
            _postReadRepository = postReadRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(PostUpdateCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _postReadRepository.GetByIdAsync(request.Id);
            responseFromDb.Overview = request.Overview;
            responseFromDb.CategoryId = request.CategoryId;
            responseFromDb.AuthorId = request.AuthorId;
            responseFromDb.Content = request.Content;
            responseFromDb.ThumbnailImage = request.ThumbnailImage;
            responseFromDb.Title = request.Title;
            await _postWriteRepository.SaveAsync();

            return ResponseDto<NoContent>.Success(204);
        }
    }
}
