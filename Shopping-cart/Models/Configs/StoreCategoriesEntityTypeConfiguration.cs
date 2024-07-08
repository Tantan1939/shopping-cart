using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping_cart.Models.Configs
{
    public class StoreCategoriesEntityTypeConfiguration : IEntityTypeConfiguration<StoreCategories>
    {
        public void Configure(EntityTypeBuilder<StoreCategories> builder)
        {
            builder
                .Property(p => p.AppCategory)
                .HasConversion(
                    v => v.ToString(),
                    v => (ProductCategories)Enum.Parse(typeof(ProductCategories), v));

            builder
                .HasOne(p => p.Store)
                .WithMany()
                .HasForeignKey(p => p.StoreId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
