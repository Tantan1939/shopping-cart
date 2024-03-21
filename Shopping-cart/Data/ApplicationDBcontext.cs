using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopping_cart.Models;

namespace Shopping_cart.Data
{
	public class ApplicationDBcontext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
		{

		}
	}
}
