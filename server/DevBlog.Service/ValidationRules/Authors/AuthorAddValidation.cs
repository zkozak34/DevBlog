using DevBlog.Service.Services.Commands.Authors.Add;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.Authors
{
    public class AuthorAddValidation : AbstractValidator<AuthorAddCommand>
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
