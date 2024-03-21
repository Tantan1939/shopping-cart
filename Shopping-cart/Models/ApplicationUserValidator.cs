using FluentValidation;

namespace Shopping_cart.Models
{
	public class ApplicationUserValidator : AbstractValidator<ApplicationUser>
	{
		public ApplicationUserValidator()
		{
			RuleFor(x => x.Birthdate)
				.Must(b => b < DateTime.Now.AddYears(-18)).WithMessage("Your age should be 18 years old and above.");
		}
	}
}
