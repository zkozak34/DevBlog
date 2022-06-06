using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Core.Utilities.Hashing;
using DevBlog.Repository.Abstract.Author;
using DevBlog.Service.Utilities.Security;
using MediatR;

namespace DevBlog.Service.Services.Queries.Authors.Login
{
    public class AuthorLoginQueryHandler : IRequestHandler<AuthorLoginQuery, ResponseDto<string>>
    {
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;

        public AuthorLoginQueryHandler(IJWTAuthenticationManager jwtAuthenticationManager, IAuthorReadRepository authorReadRepository)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _authorReadRepository = authorReadRepository;
        }

        public async Task<ResponseDto<string>> Handle(AuthorLoginQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _authorReadRepository.GetSingleWhereAsync(a => a.Email == request.Email && a.Password == Security.Encrypt(request.Password, ServiceRegistration.SaltKey));
            if (responseFromDb is not null)
            {
                var token = _jwtAuthenticationManager.Authenticate(Guid.Parse(responseFromDb.Id.ToString()), responseFromDb.Email,
                    responseFromDb.FullName);
                return ResponseDto<string>.Success(token, 200);
            }
            return ResponseDto<string>.Fail("Email or Password is incorrent!", 400);
        }
    }
}
