using AutoMapper;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Category;
using DevBlog.Repository.Abstract.Category;
using MediatR;

namespace DevBlog.Service.Services.Queries.Categories.GetAll
{
    public class CategoryGetAllQueryHandler : IRequestHandler<CategoryGetAllQuery, ResponseDto<IEnumerable<CategoryDto>>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;
        public CategoryGetAllQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        //var responseFromDb = await _categoryRepository.GetAll();
        //if (responseFromDb.Count > 0)
        //    return ResponseDto<List<Category>>.Success(responseFromDb, 200);
        //return ResponseDto<List<Category>>.Fail(500);
        public Task<ResponseDto<IEnumerable<CategoryDto>>> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = _categoryReadRepository.GetAll(false);
            if (responseFromDb.Any())
                return Task.FromResult(ResponseDto<IEnumerable<CategoryDto>>.Success(_mapper.Map<IEnumerable<CategoryDto>>(responseFromDb), 200));
            return Task.FromResult(ResponseDto<IEnumerable<CategoryDto>>.Fail(204));
        }
    }
}
