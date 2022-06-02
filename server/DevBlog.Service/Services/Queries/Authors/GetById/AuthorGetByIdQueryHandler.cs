using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Author;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Queries.Authors.GetById
{
    public class AuthorGetByIdQueryHandler : IRequestHandler<AuthorGetByIdQuery, ResponseDto<AuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorGetByIdQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<ResponseDto<AuthorDto>> Handle(AuthorGetByIdQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _authorRepository.GetById(request.Id);
            if (responseFromDb.FullName != null)
                return ResponseDto<AuthorDto>.Success(responseFromDb, 200);
            return ResponseDto<AuthorDto>.Success(204);
        }
    }
}
