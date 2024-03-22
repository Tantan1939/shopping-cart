using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shopping_cart.ViewModels.Account
{
    public class AccountLoginViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember Me?")]
        public bool RememberMe { get; set; } = false;
    }
}
