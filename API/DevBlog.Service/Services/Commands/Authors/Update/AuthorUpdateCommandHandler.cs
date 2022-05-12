using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Commands.Authors.Update
{
    public class AuthorUpdateCommandHandler : IRequestHandler<AuthorUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorUpdateCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(AuthorUpdateCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _authorRepository.Update(request.Id, request.AuthorUpdateDto);
            if (responseFromDb)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail(500);
        }
    }
}
