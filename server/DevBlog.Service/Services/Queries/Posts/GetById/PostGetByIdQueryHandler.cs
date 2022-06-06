using AutoMapper;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Post;
using DevBlog.Repository.Abstract.Post;
using MediatR;
using System.Net;

namespace DevBlog.Service.Services.Queries.Posts.GetById
{
    public class PostGetByIdQueryHandler : IRequestHandler<PostGetByIdQuery, ResponseDto<PostDto>>
    {
        private readonly IPostReadRepository _postReadRepository;
        private readonly IMapper _mapper;

        public PostGetByIdQueryHandler(IPostReadRepository authorReadRepository, IMapper mapper)
        {
            _postReadRepository = authorReadRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<PostDto>> Handle(PostGetByIdQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _postReadRepository.GetByIdAsync(request.Id, false);
            if (responseFromDb != null)
                return ResponseDto<PostDto>.Success(_mapper.Map<PostDto>(responseFromDb), 200);
            return ResponseDto<PostDto>.Fail((int)HttpStatusCode.BadRequest);
        }
    }
}
