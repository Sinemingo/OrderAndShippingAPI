using Microsoft.EntityFrameworkCore;
using OrderAndShippingAPI.Data.Concrete.EFCore.Mappings;
using OrderAndShippingAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Data.Concrete.EFCore.Contexts
{
    public class OrderAndShippingContext:DbContext
    {
        public OrderAndShippingContext()
        {
        }

        public OrderAndShippingContext(DbContextOptions<OrderAndShippingContext> options) : base(options)
        {

        }        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=DESKTOP-BSDG0CD;Database=OrderAndShipping;Trusted_Connection=True;MultipleActiveResultSets=True;");
        //}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ShippingCompany> ShippingCompanies { get; set; }


        //public static void MigrationUpdate()
        //{
        //    try
        //    {
        //        using (var db = new OrderAndShippingContext())
        //        {
        //            db.Database.Migrate();
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        throw new Exception(err.Message, err);
        //    }
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderLineMap());
            modelBuilder.ApplyConfiguration(new ShippingCompanyMap());

        }
    }
}
