using BlogStar.Shared.Requests.Authentication.Commands;
using FluentValidation;

namespace BlogStar.Shared.Validators.Authentication
{
    public class RegistrationValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegistrationValidator() 
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Please enter proper email")
                .MaximumLength(200).WithMessage("Email should not be longer than 200 characters")
                .MinimumLength(5).WithMessage("Email should be atleast 5 characters long");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be atleast 8 characters long");

            RuleFor(p => p.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm password is required")
                .DependentRules(() =>
                {
                    RuleFor(p => new { p.Password, p.ConfirmPassword })
                    .MustAsync(async (model, cancellationToken) =>
                    {
                        return await ComparePasswords(model.Password, model.ConfirmPassword, cancellationToken);
                    })
                    .WithMessage("Password and confirm password are not same");
                });
        }

        public async Task<bool> ComparePasswords(string password, string confirmPassword, CancellationToken cancellationToken)
        {
            return String.Equals(password, confirmPassword);
        }
    }
}
