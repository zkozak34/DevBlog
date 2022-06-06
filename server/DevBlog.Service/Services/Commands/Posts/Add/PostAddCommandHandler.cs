using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using DevBlog.Repository.Abstract.Post;
using MediatR;
using System.Net;

namespace DevBlog.Service.Services.Commands.Posts.Add
{
    public class PostAddCommandHandler : IRequestHandler<PostAddCommand, ResponseDto<NoContent>>
    {
        private readonly IPostWriteRepository _postWriteRepository;

        public PostAddCommandHandler(IPostWriteRepository authorWriteRepository)
        {
            _postWriteRepository = authorWriteRepository;
        }
        public async Task<ResponseDto<NoContent>> Handle(PostAddCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _postWriteRepository.AddAsync(new Post()
            {
                Overview = request.Overview,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                Content = request.Content,
                ThumbnailImage = request.ThumbnailImage,
                Title = request.Title,
            });
            await _postWriteRepository.SaveAsync();
            if (responseFromDb)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail((int)HttpStatusCode.BadRequest);
        }
    }
}
