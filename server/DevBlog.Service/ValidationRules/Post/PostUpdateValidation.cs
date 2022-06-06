using DevBlog.Entities.Dtos.Post;
using DevBlog.Service.Services.Commands.Posts.Update;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.Post
{
    public class PostUpdateValidation : AbstractValidator<PostUpdateCommand>
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
