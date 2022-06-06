using AutoMapper;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Author;
using DevBlog.Repository.Abstract.Author;
using MediatR;
using System.Net;

namespace DevBlog.Service.Services.Queries.Authors.GetById
{
    public class AuthorGetByIdQueryHandler : IRequestHandler<AuthorGetByIdQuery, ResponseDto<AuthorDto>>
    {
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly IMapper _mapper;

        public AuthorGetByIdQueryHandler(IAuthorReadRepository authorReadRepository, IMapper mapper)
        {
            _authorReadRepository = authorReadRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<AuthorDto>> Handle(AuthorGetByIdQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _authorReadRepository.GetByIdAsync(request.Id, false);
            if (responseFromDb != null)
                return ResponseDto<AuthorDto>.Success(_mapper.Map<AuthorDto>(responseFromDb), 200);
            return ResponseDto<AuthorDto>.Fail((int)HttpStatusCode.BadRequest);
        }
    }
}
