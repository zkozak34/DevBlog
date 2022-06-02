using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Queries.Categories.GetAll
{
    internal class CategoryGetAllQueryHandler : IRequestHandler<CategoryGetAllQuery, ResponseDto<List<Category>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryGetAllQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseDto<List<Category>>> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _categoryRepository.GetAll();
            if (responseFromDb.Count > 0)
                return ResponseDto<List<Category>>.Success(responseFromDb, 200);
            return ResponseDto<List<Category>>.Success(204);
        }
    }
}
