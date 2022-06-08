using DevBlog.Service.Services.Commands.Users.Create;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.User
{
    public class UserCreateValidation : AbstractValidator<UserCreateCommand>
    {
        public UserCreateValidation()
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
