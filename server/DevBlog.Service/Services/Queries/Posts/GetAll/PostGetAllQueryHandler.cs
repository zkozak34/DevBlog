using AutoMapper;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Post;
using DevBlog.Repository.Abstract.Post;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace DevBlog.Service.Services.Queries.Posts.GetAll
{
    public class PostGetAllQueryHandler : IRequestHandler<PostGetAllQuery, ResponseDto<IEnumerable<PostDto>>>
    {
        private readonly IPostReadRepository _postReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public PostGetAllQueryHandler(IPostReadRepository postRepository, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _postReadRepository = postRepository;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        public Task<ResponseDto<IEnumerable<PostDto>>> Handle(PostGetAllQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = _postReadRepository.GetAll(false);
            if (responseFromDb.Any())
                return Task.FromResult(ResponseDto<IEnumerable<PostDto>>.Success(_mapper.Map<IEnumerable<PostDto>>(responseFromDb), 200));
            return Task.FromResult(ResponseDto<IEnumerable<PostDto>>.Fail(204));
        }
    }
}
