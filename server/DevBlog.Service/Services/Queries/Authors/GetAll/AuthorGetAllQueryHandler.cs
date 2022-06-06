using AutoMapper;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Author;
using DevBlog.Repository.Abstract.Author;
using MediatR;

namespace DevBlog.Service.Services.Queries.Authors.GetAll
{
    public class AuthorGetAllQueryHandler : IRequestHandler<AuthorGetAllQuery, ResponseDto<IEnumerable<AuthorDto>>>
    {
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly IMapper _mapper;

        public AuthorGetAllQueryHandler(IAuthorReadRepository authorReadRepository, IMapper mapper)
        {
            _authorReadRepository = authorReadRepository;
            _mapper = mapper;
        }

        public Task<ResponseDto<IEnumerable<AuthorDto>>> Handle(AuthorGetAllQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = _authorReadRepository.GetAll(false);
            if (responseFromDb.Any())
                return Task.FromResult(ResponseDto<IEnumerable<AuthorDto>>.Success(_mapper.Map<IEnumerable<AuthorDto>>(responseFromDb), 200));
            return Task.FromResult(ResponseDto<IEnumerable<AuthorDto>>.Fail(204));
        }
    }
}
