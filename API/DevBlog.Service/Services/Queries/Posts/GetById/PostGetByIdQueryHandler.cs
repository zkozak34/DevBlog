using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Queries.Posts.GetById
{
    public class PostGetByIdQueryHandler : IRequestHandler<PostGetByIdQuery, ResponseDto<Post>>
    {
        private readonly IPostRepository _postRepository;

        public PostGetByIdQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ResponseDto<Post>> Handle(PostGetByIdQuery request, CancellationToken cancellationToken)
        {
            var responseFromDatabase = await _postRepository.GetById(request.Id);
            if (responseFromDatabase == null)
                return ResponseDto<Post>.Fail(500);
            return ResponseDto<Post>.Success(responseFromDatabase, 200);
        }
    }
}
