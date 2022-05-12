using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Core.Utilities.Hashing;
using DevBlog.Entities.Dtos.Author;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Queries.Authors.Login
{
    public class AuthorLoginQueryHandler : IRequestHandler<AuthorLoginQuery, ResponseDto<AuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorLoginQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<ResponseDto<AuthorDto>> Handle(AuthorLoginQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _authorRepository.Login(request.Email, Security.Encrypt(request.Password, ServiceRegistration.SaltKey));
            if(responseFromDb.Email != null)
                return ResponseDto<AuthorDto>.Success(responseFromDb, 200);
            return ResponseDto<AuthorDto>.Fail(500);
        }
    }
}
