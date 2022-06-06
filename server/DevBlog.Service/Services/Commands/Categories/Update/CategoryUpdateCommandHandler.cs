using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract.Category;
using MediatR;

namespace DevBlog.Service.Services.Commands.Categories.Update
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;

        public CategoryUpdateCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _categoryReadRepository.GetByIdAsync(request.Id);
            responseFromDb.Title = request.Title;
            responseFromDb.Path = request.Path;
            await _categoryWriteRepository.SaveAsync();

            return ResponseDto<NoContent>.Success(204);
        }
    }
}
