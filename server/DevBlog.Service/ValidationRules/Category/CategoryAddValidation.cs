using DevBlog.Service.Services.Commands.Categories.Add;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.Category
{
    public class CategoryAddValidation : AbstractValidator<CategoryAddCommand>
    {
        public CategoryAddValidation()
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
