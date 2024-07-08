using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping_cart.Models.Configs
{
    public class SellerApplicationEntityTypeConfiguration : IEntityTypeConfiguration <ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasMany<SellerApplications>()
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);
        }
    }
}
