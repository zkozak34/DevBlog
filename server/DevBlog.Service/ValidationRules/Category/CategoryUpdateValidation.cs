using DevBlog.Service.Services.Commands.Categories.Update;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.Category
{
    public class CategoryUpdateValidation : AbstractValidator<CategoryUpdateCommand>
    {
        public CategoryUpdateValidation()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.Path)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
