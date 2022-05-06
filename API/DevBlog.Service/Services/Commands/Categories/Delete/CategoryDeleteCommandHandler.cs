using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Commands.Categories.Delete
{
    public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, ResponseDto<NoContent>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryDeleteCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _categoryRepository.Delete(request.Id);
            if (responseFromDb)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail(500);
        }
    }
}
