using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Commands.Authors.Delete
{
    public class AuthorDeleteCommandHandler : IRequestHandler<AuthorDeleteCommand, ResponseDto<NoContent>>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorDeleteCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(AuthorDeleteCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _authorRepository.Delete(request.Id);
            if (responseFromDb)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail(500);
        }
    }
}
