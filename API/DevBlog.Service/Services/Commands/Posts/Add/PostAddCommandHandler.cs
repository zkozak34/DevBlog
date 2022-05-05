using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Commands.Posts.Add
{
    internal class PostAddCommandHandler : IRequestHandler<PostAddCommand, ResponseDto<NoContent>>
    {
        private readonly IPostRepository _postRepository;

        public PostAddCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(PostAddCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _postRepository.Add(request.PostAddDto);
            if(responseFromDb)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail(500);
        }
    }
}
