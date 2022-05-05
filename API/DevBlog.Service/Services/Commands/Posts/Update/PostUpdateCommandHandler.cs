using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Commands.Posts.Update
{
    public class PostUpdateCommandHandler : IRequestHandler<PostUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly IPostRepository _postRepository;

        public PostUpdateCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(PostUpdateCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _postRepository.Update(request.Id, request.PostUpdateDto);
            if(responseFromDb)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail(500);
        }
    }
}
