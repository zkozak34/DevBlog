using DevBlog.Service.Services.Commands.Authors.Update;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.Authors
{
    public class AuthorUpdateValidation : AbstractValidator<AuthorUpdateCommand>
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
