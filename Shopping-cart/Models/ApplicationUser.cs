using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Shopping_cart.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public DateTime? Birthdate { get; set; }

		public string UrlPicture { get; set; } = "~/images/default-profile.png";

        public readonly DateTime DateCreated = DateTime.Now;
		public DateTime? LastLogin { get; set; }

		public string GetName()
		{
			var name = "";

			if (FirstName != null)
			{
				name += FirstName;
			}

			if (LastName != null)
			{
				name += LastName;
			}

			if (name != "")
			{
				return name;
			}
			else
			{
				return Email;
			}
		}
	}
}
