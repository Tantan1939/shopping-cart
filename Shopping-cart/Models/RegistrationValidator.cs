using FluentValidation;

namespace Shopping_cart.Models
{
    public class RegistrationValidator : AbstractValidator<Registration>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is Required.")
                .Length(5, 30).WithMessage("Username must be between 5 and 30 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is Required.")
                .EmailAddress().WithMessage("Valid Email Address is Required.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is Required.")
                .Length(6, 100).WithMessage("Password must be between 6 and 100 characters.");
        }
    }
}
