using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using DevBlog.Repository.Abstract;
using MediatR;

namespace DevBlog.Service.Services.Queries.Categories.GetById
{
    internal class CategoryGetByIdQueryHandler : IRequestHandler<CategoryGetByIdQuery, ResponseDto<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryGetByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseDto<Category>> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _categoryRepository.GetById(request.Id);
            if (responseFromDb != null)
                return ResponseDto<Category>.Success(responseFromDb, 200);
            return ResponseDto<Category>.Fail(500);
        }
    }
}
