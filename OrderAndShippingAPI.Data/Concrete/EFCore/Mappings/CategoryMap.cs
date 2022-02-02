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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryId).ValueGeneratedOnAdd();
            builder.Property(c => c.CategoryName).HasMaxLength(100);
            builder.Property(c => c.CategoryName).IsRequired();
            builder.HasOne<ShippingCompany>(c => c.ShippingCompany).WithMany(s => s.Categories)
               .HasForeignKey(c => c.CategoryId);
            builder.ToTable("Categories");
            builder.HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Gıda"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Giyim"
                }
                );

        }
    }
}
