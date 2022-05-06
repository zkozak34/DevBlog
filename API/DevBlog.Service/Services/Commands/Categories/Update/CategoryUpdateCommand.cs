using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Category;
using MediatR;

namespace DevBlog.Service.Services.Commands.Categories.Update
{
    public class CategoryUpdateCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
        public CategoryUpdateDto CategoryUpdateDto { get; set; }
    }
}
