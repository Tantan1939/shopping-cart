using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Shopping_cart.ViewModels.Account
{
    public class AccountProfileViewModel
    {
        [Display(Name = "First Name")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Minimum of 2 characters up to 10 characters only.")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Must be characters from a - z or A - Z only.")]
        public string? FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Minimum of 2 characters up to 10 characters only.")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Must be characters from a - z or A - Z only.")]
        public string? MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Minimum of 2 characters up to 10 characters only.")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Must be characters from a - z or A - Z only.")]
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength =11, ErrorMessage = "Exact 11 numbers only.")]
        public string? PhoneNumber { get; set; }
    }
}
