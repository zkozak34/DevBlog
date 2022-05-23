using DevBlog.Entities.Dtos.Post;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.Post
{
    public class PostUpdateValidation : AbstractValidator<PostUpdateDto>
    {
        public PostUpdateValidation()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .MinimumLength(8);

            RuleFor(x => x.Content)
                .NotNull()
                .MinimumLength(8);

            RuleFor(x => x.Overview)
                .NotNull()
                .MinimumLength(8)
                .MaximumLength(250);

            RuleFor(x => x.ThumbnailImage)
                .NotNull();

            RuleFor(x => x.CategoryId)
                .NotNull();

            RuleFor(x => x.CategoryId)
                .NotNull();
        }
    }
}
