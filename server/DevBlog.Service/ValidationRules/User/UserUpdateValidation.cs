using DevBlog.Service.Services.Commands.Users.Update;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.User
{
    public class UserUpdateValidation : AbstractValidator<UserUpdateCommand>
    {
        public UserUpdateValidation()
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
