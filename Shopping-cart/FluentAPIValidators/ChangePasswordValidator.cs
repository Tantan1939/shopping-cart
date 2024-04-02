using FluentValidation;
using Shopping_cart.ViewModels.Account;

namespace Shopping_cart.FluentAPIValidators
{
    public class ChangePasswordValidator : AbstractValidator<AccountChangePasswordViewModel>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.Password)
                .NotEqual(y => y.OldPassword).WithMessage("New password should not match the old password.");
        }
    }
}
