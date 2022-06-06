using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using DevBlog.Repository.Abstract.Category;
using MediatR;
using System.Net;

namespace DevBlog.Service.Services.Commands.Categories.Add
{
    public class CategoryAddCommandHandler : IRequestHandler<CategoryAddCommand, ResponseDto<NoContent>>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public CategoryAddCommandHandler(ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _categoryWriteRepository.AddAsync(new Category() { Title = request.Title, Path = request.Path });
            await _categoryWriteRepository.SaveAsync();
            if (responseFromDb)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail((int)HttpStatusCode.BadRequest);
        }
    }
}
