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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.UserId).ValueGeneratedOnAdd();
            builder.Property(u => u.UserName).HasMaxLength(100);
            builder.Property(u => u.UserName).IsRequired();
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.Property(u => u.LastName).HasMaxLength(100);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(100);
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Password).HasColumnType("NVARCHAR(50)");
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasOne<Role>(u => u.Role).WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
            builder.ToTable("Users");
            builder.HasData(new User
            {
                UserId = 1,
                RoleId = 1,
                FirstName = "Sinem",
                LastName = "Mutlu",
                UserName = "sinemmutlu",
                Email = "sinem@mail.com",
                Password ="123456"
            });

        }
    }
}
