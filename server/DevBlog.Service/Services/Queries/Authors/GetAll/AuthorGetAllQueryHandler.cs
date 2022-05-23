using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Author;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Queries.Authors.GetAll
{
    public class AuthorGetAllQueryHandler : IRequestHandler<AuthorGetAllQuery, ResponseDto<List<AuthorDto>>>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorGetAllQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<ResponseDto<List<AuthorDto>>> Handle(AuthorGetAllQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _authorRepository.GetAll();
            if (responseFromDb.Count > 0)
                return ResponseDto<List<AuthorDto>>.Success(responseFromDb, 200);
            return ResponseDto<List<AuthorDto>>.Fail(500);
        }
    }
}
