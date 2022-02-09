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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasKey(o => o.OrderId);
            builder.Property(o => o.OrderId).ValueGeneratedOnAdd();
            builder.Property(o => o.OrderDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(o => o.TotalOrderPrice).IsRequired();
            builder.Property(o => o.Statu).IsRequired().HasDefaultValueSql("0");
            builder.HasOne<User>(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);
            builder.ToTable("Orders");
            builder.HasData(
             new Order
             {
                 OrderId=1,
                 OrderDate= DateTime.Now, 
                 TotalOrderPrice=35.50,
                 Statu=Entities.Abstract.Enums.EShippingStatu.Pending,
                 UserId=1,

             },
             new Order
             {
                 OrderId = 2,
                 OrderDate = DateTime.Now,
                 TotalOrderPrice = 75.50,
                 Statu = Entities.Abstract.Enums.EShippingStatu.Pending,
                 UserId = 1,
             }
             );

        }
    }
}
