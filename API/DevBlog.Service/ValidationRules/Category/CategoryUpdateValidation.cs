using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Entities.Dtos.Category;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.Category
{
    public class CategoryUpdateValidation : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidation()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
