using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Commands.Categories.Update
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryUpdateCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _categoryRepository.Update(request.Id, request.CategoryUpdateDto);
            if (responseFromDb)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail(500);
        }
    }
}
