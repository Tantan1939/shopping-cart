using System.ComponentModel.DataAnnotations;

namespace Shopping_cart.ViewModels.Account
{
	public class AccountCreateViewModel
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Confirm Password must match to the Password. Try again.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
