using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Author;
using DevBlog.Repository.Abstract;
using DevBlog.Service.Utilities.Hashing;
using MediatR;

namespace DevBlog.Service.Services.Commands.Authors.Add
{
    public class AuthorAddCommandHandler : IRequestHandler<AuthorAddCommand, ResponseDto<NoContent>>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorAddCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // TODO: PASSWORD HASH!!!!
        public async Task<ResponseDto<NoContent>> Handle(AuthorAddCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _authorRepository.Add(new AuthorAddDto()
            {
                FullName = request.AddCommand.FullName,
                Email = request.AddCommand.Email,
                Overview = request.AddCommand.Overview,
                Password = Security.Encrypt(request.AddCommand.Password),
                ProfileImage = request.AddCommand.ProfileImage,

            });
            if (responseFromDb)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail(500);
        }
    }
}
