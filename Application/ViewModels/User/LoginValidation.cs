using FluentValidation;

namespace Application.ViewModels.User
{
    public class LoginValidation : AbstractValidator<LoginRequest>
    {
        public LoginValidation()
        {
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("User name cannot empty!");
            RuleFor(x=>x.password).NotEmpty().WithMessage("Password cannot empty!");
        }
    }
}