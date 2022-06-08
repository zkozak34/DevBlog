using DevBlog.Service.Services.Commands.Users.Create;
using FluentValidation;

namespace DevBlog.Service.ValidationRules.User
{
<<<<<<<< HEAD:server/DevBlog.Service/ValidationRules/User/UserAddValidation.cs
    public class UserAddValidation : AbstractValidator<UserCreateCommand>
    {
        public UserAddValidation()
========
    public class UserCreateValidation : AbstractValidator<UserCreateCommand>
    {
        public UserCreateValidation()
>>>>>>>> feature/identity_role:server/DevBlog.Service/ValidationRules/User/UserCreateValidation.cs
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
