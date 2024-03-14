using FluentValidation;

namespace Shopping_cart.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(6, 12).WithMessage("Username must be between 6 and 12 characters.")
                .Matches(@"^[a-zA-Z0-9]+").WithMessage("Username should be alphanumeric only.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Not a valid email. Try again.")
                .Length(8, 30).WithMessage("Email length must be between 8 and 30 characters only.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Length(8, 30).WithMessage("Password length should be between 8 and 30 characters.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required.")
                .Equal(p => p.Password).WithMessage("Confirm password must match Password.");
        }
    }
}
