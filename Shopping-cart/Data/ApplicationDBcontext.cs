using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopping_cart.Models;
using Shopping_cart.Models.Configs;
using System.Reflection.Emit;

namespace Shopping_cart.Data
{
	public class ApplicationDBcontext : IdentityDbContext<ApplicationUser>
	{
        public DbSet<SellerApplications> SellerApplications { get; set; }

        public DbSet<Stores> Stores { get; set; }

        public DbSet<StoreCategories> StoreCategories { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Carts> Carts { get; set; }

        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Include base configuration

            new SellerApplicationEntityTypeConfiguration().Configure(builder.Entity<ApplicationUser>());

            new StoresEntityTypeConfiguration().Configure(builder.Entity<Stores>());

            new StoreCategoriesEntityTypeConfiguration().Configure(builder.Entity<StoreCategories>());

            new ProductsEntityTypeConfiguration().Configure(builder.Entity<Products>());

            new CartEntityTypeConfiguration().Configure(builder.Entity<Carts>());
        }
    }
}
