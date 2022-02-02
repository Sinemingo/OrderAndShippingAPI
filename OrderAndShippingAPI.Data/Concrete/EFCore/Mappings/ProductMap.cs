using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderAndShippingAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Data.Concrete.EFCore.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductId).ValueGeneratedOnAdd();
            builder.Property(p => p.ProductName).HasMaxLength(100);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.ProductDescription).HasMaxLength(100);
            builder.Property(p => p.ProductImgUrl).HasMaxLength(100);
            builder.HasOne<Category>(p => p.Category).WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
            builder.ToTable("Products");
            builder.HasData(
               new Product
               {
                   ProductId = 1,
                   ProductName = "Makarna",
                   Price = 15.50,
                   CategoryId = 1
               },
               new Product
               {
                    ProductId = 2,
                    ProductName = "Yogurt",
                    Price = 20.00,
                    CategoryId = 1
                },
                new Product
                {
                     ProductId = 3,
                     ProductName = "Kazak",
                     Price = 65.00,
                     CategoryId = 2
                },
                 new Product
                 {
                      ProductId = 4,
                      ProductName = "Bere",
                      Price = 10.50,
                      CategoryId = 2
                 }
               );
        }
    }
}
