using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvc.Models.Entities;

namespace Mvc.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(a => a.Category)
                .WithMany(a => a.Products)
                .HasForeignKey(a => a.CategoryId);

            builder.HasIndex(a => a.ProductName).IsUnique(true);
        }
    }
}
