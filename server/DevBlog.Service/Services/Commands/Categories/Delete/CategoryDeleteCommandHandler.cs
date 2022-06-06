using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract.Category;
using MediatR;
using System.Net;

namespace DevBlog.Service.Services.Commands.Categories.Delete
{
    public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, ResponseDto<NoContent>>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public CategoryDeleteCommandHandler(ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _categoryWriteRepository.Delete(request.Id);
            await _categoryWriteRepository.SaveAsync();
            if (responseFromDb)
                return ResponseDto<NoContent>.Success(204);
            return ResponseDto<NoContent>.Fail((int)HttpStatusCode.BadRequest);
        }
    }
}
