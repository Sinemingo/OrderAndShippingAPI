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
    public class ShippingCompanyMap : IEntityTypeConfiguration<ShippingCompany>
    {
        public void Configure(EntityTypeBuilder<ShippingCompany> builder)
        {
            builder.HasKey(s => s.ShippingCompanyId);
            builder.Property(s => s.ShippingCompanyId).ValueGeneratedOnAdd();
            builder.Property(s => s.ShippingCompanyName).HasMaxLength(100);
            builder.Property(s => s.ShippingCompanyName).IsRequired();
            builder.ToTable("ShippingCompanies");
            builder.HasData(
               new ShippingCompany
               {
                   ShippingCompanyId = 1,
                   ShippingCompanyName ="YurticiKargo"
               },
               new ShippingCompany
               {
                   ShippingCompanyId = 2,
                   ShippingCompanyName = "ArasKargo"
               }
               );
        }
    }
}
