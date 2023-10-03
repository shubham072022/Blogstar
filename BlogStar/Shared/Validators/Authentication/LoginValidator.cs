using BlogStar.Shared.Requests.Authentication.Commands;
using FluentValidation;

namespace BlogStar.Shared.Validators.Authentication
{
    public class LoginValidator : AbstractValidator<LoginCommandRequest>
    {
        public LoginValidator() 
        {
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Please enter proper email");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
