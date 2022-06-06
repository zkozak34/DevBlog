using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract.Author;
using MediatR;
using System.Net;

namespace DevBlog.Service.Services.Commands.Authors.Delete
{
    public class AuthorDeleteCommandHandler : IRequestHandler<AuthorDeleteCommand, ResponseDto<NoContent>>
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;

        public AuthorDeleteCommandHandler(IAuthorWriteRepository authorWriteRepository)
        {
            _authorWriteRepository = authorWriteRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(AuthorDeleteCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _authorWriteRepository.Delete(request.Id);
            await _authorWriteRepository.SaveAsync();
            if (responseFromDb)
                return ResponseDto<NoContent>.Success(204);
            return ResponseDto<NoContent>.Fail((int)HttpStatusCode.BadRequest);
        }
    }
}
