using FluentValidation;
using Shopping_cart.Models;
using Shopping_cart.ViewModels.Account;

namespace Shopping_cart.FluentAPIValidators
{
    public class AccountProfileValidator : AbstractValidator<AccountProfileViewModel>
    {
        public AccountProfileValidator()
        {
            RuleFor(x => x.Birthdate)
                .Must(b => b < DateTime.Now.AddYears(-18)).WithMessage("Your age should be 18 years old and above.");
        }
    }
}
