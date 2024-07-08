using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping_cart.Models.Configs
{
    public class CartEntityTypeConfiguration : IEntityTypeConfiguration<Carts>
    {
        public void Configure(EntityTypeBuilder<Carts> builder)
        {
            builder
                .HasOne(u => u.User)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
