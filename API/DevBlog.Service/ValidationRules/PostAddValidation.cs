﻿using DevBlog.Entities.Dtos.Post;
using FluentValidation;

namespace DevBlog.Service.ValidationRules
{
    public class PostAddValidation : AbstractValidator<PostAddDto>
    {
        public PostAddValidation()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .MinimumLength(8);

            RuleFor(x => x.Content)
                .NotNull()
                .MinimumLength(8);

            RuleFor(x => x.ThumbnailImage)
                .NotNull();

            RuleFor(x => x.CategoryId)
                .NotNull();

            RuleFor(x => x.CategoryId)
                .NotNull();
        }
    }
}
