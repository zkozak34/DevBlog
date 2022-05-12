using DevBlog.Entities.Dtos.Category;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.Category
{
    public class CategoryAddValidation : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidation()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
