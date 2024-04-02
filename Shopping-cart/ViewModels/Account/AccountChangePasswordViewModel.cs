using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Shopping_cart.ViewModels.Account
{
    public class AccountChangePasswordViewModel : AccountPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }
    }
}
