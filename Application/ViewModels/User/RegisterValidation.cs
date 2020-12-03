using FluentValidation;

namespace Application.ViewModels.User
{
    public class RegisterValidation : AbstractValidator<RegisterRequest>
    {
        public RegisterValidation()
        {
            RuleFor(x=>x.LastName).NotEmpty().WithMessage("Cannot empty");
            RuleFor(x=>x.FirstName).NotEmpty().WithMessage("Cannot empty");
            RuleFor(x=>x.Dob).NotEmpty().WithMessage("Your birthday cannot empty");
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("User cannot empty");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email cannot empty");
            RuleFor(x=>x.password).NotEmpty().WithMessage("Password cannot empty")
                .MinimumLength(6).WithMessage("Password require 6 letters");
            RuleFor(x=>x.Address).NotEmpty().WithMessage("Address cannot empty");
            RuleFor(x=>x.PhoneNumber).MaximumLength(10).WithMessage("This is not a phone number")
            .NotEmpty().WithMessage("Phone number cannot empty");
        }
    }
}