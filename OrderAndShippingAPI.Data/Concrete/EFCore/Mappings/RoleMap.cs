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
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.RoleId);
            builder.Property(r => r.RoleId).ValueGeneratedOnAdd();
            builder.Property(r => r.RoleName).HasMaxLength(100);
            builder.Property(r => r.RoleName).IsRequired();
            builder.Property(r => r.RoleDescription).HasMaxLength(100);
            builder.Property(r => r.RoleDescription).IsRequired();
            builder.ToTable("Roles");
            builder.HasData(new Role
            {
                RoleId = 1,
                RoleName = "Admin",
                RoleDescription = "Admin Rolü"
            },
             new Role
             {
                 RoleId =2,
                 RoleName = "Kullanıcı",
                 RoleDescription = "Kullanıcı Rolü"
             });
        }
    }
}
