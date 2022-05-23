using DevBlog.Entities.Dtos.Author;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.Authors
{
    public class AuthorAddValidation : AbstractValidator<AuthorAddDto>
    {
        public AuthorAddValidation()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.FullName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8);
        }
    }
}
