using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvc.Models.Entities;

namespace Mvc.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(u => u.CategoryId);
            builder.HasIndex(u => u.CategoryName).IsUnique(true);
        }
    }
}
