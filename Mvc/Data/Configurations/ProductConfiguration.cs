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

            builder.HasData(
                new Product
                {
                    CategoryId = 2,
                    ProductId = 1,
                    ProductName = "Samsung",
                    ProductImage = ReadFile("C:\\Users\\Hp\\Desktop\\AuthDeneme\\Mvc\\wwwroot\\img\\samsung.jpg")
                });
        }

        private static byte[] ReadFile(string path)
        {
            byte[] data = null;

            FileInfo fInfo = new FileInfo(path);
            long numBytes = fInfo.Length;

            FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fStream);

            data = br.ReadBytes((int)numBytes);

            return data;
        }
    }
}
