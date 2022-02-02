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
    public class OrderLineMap : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasKey(ol => ol.OrderLineId);
            builder.Property(ol => ol.OrderLineId).ValueGeneratedOnAdd();
            builder.Property(ol => ol.Quantity).IsRequired();
            builder.HasOne<Order>(ol => ol.Order).WithMany(o => o.OrderLines)
                .HasForeignKey(ol => ol.OrderId); 
            builder.ToTable("OrderLines");
            builder.HasData(
            new OrderLine
            {
                OrderLineId = 1,
                Quantity=1,

                ProductId=1,
                OrderId=1
            },
             new OrderLine
             {
                 OrderLineId = 2,
                 Quantity = 1,
                 ProductId = 2,
                 OrderId = 1
             },
              new OrderLine
              {
                  OrderLineId = 3,
                  Quantity = 1,
                  ProductId = 3,
                  OrderId = 2
              },
               new OrderLine
               {
                   OrderLineId = 4,
                   Quantity = 1,
                   ProductId = 4,
                   OrderId = 2
               }
            );
        }
    }
}
