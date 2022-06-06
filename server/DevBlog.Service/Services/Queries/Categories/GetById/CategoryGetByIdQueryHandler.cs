using AutoMapper;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Category;
using DevBlog.Repository.Abstract.Category;
using MediatR;
using System.Net;

namespace DevBlog.Service.Services.Queries.Categories.GetById
{
    public class CategoryGetByIdQueryHandler : IRequestHandler<CategoryGetByIdQuery, ResponseDto<CategoryDto>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public CategoryGetByIdQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<CategoryDto>> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _categoryReadRepository.GetByIdAsync(request.Id);
            if (responseFromDb != null)
                return ResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(responseFromDb), 200);
            return ResponseDto<CategoryDto>.Fail((int)HttpStatusCode.BadRequest);
        }
    }
}
