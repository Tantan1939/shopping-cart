using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping_cart.Models.Configs
{
    public class StoresEntityTypeConfiguration : IEntityTypeConfiguration<Stores>
    {
        public void Configure(EntityTypeBuilder<Stores> builder)
        {
            builder
                .Property(s => s.DateCreated).HasDefaultValueSql("getdate()");

            builder
                .HasOne(s => s.User)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
