using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Commands.Categories.Add
{
    public class CategoryAddCommandHandler : IRequestHandler<CategoryAddCommand, ResponseDto<NoContent>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAddCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _categoryRepository.Add(request.CategoryAddDto);
            if(responseFromDb)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail(500);
        }
    }
}
