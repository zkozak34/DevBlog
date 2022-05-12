using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Core.Utilities.Hashing;
using DevBlog.Repository.Abstract;
using DevBlog.Service.Utilities.Security;
using MediatR;

namespace DevBlog.Service.Services.Queries.Authors.Login
{
    public class AuthorLoginQueryHandler : IRequestHandler<AuthorLoginQuery, ResponseDto<string>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;

        public AuthorLoginQueryHandler(IAuthorRepository authorRepository, IJWTAuthenticationManager jwtAuthenticationManager)
        {
            _authorRepository = authorRepository;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        public async Task<ResponseDto<string>> Handle(AuthorLoginQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _authorRepository.Login(request.Email, Security.Encrypt(request.Password, ServiceRegistration.SaltKey));
            if (responseFromDb.Email != null)
            {
                var token = _jwtAuthenticationManager.Authenticate(responseFromDb.Id, request.Email);
                return ResponseDto<string>.Success(token, 200);
            }
            return ResponseDto<string>.Fail(401);
        }
    }
}
