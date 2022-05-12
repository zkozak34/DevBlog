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
