using System.ComponentModel.DataAnnotations;

namespace Shopping_cart.ViewModels.Account
{
    public class AccountEmailViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
