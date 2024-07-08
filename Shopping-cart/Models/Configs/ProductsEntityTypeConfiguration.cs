using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping_cart.Models.Configs
{
    public class ProductsEntityTypeConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(s => s.Store)
                .WithMany()
                .HasForeignKey(s => s.StoreId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(p => p.Created)
                .HasDefaultValueSql("getdate()");

            builder
                .Property(p => p.IsHidden)
                .HasConversion<int>()
                .HasDefaultValue(0);
        }
    }
}
