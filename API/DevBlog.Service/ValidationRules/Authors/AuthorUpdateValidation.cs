using DevBlog.Entities.Dtos.Author;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.Authors
{
    public class AuthorUpdateValidation : AbstractValidator<AuthorUpdateDto>
    {
        public AuthorUpdateValidation()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.FullName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);
        }
    }
}
