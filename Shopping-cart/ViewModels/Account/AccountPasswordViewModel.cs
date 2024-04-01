using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Shopping_cart.ViewModels.Account
{
	public class AccountPasswordViewModel
	{
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "New Password")]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Confirm Password must match to the Password. Try again.")]
		[Display(Name = "Confirm New Password")]
		public string ConfirmPassword { get; set; }
	}
}
