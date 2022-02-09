﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderAndShippingAPI.Data.Concrete.EFCore.Contexts;

namespace OrderAndShippingAPI.Data.Migrations
{
    [DbContext(typeof(OrderAndShippingContext))]
    [Migration("20220204144705_FirstMig3")]
    partial class FirstMig3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ShippingCompanyId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Gıda",
                            ShippingCompanyId = 0
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Giyim",
                            ShippingCompanyId = 0
                        });
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 4, 17, 47, 4, 464, DateTimeKind.Local).AddTicks(7211));

                    b.Property<int>("Statu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("0");

                    b.Property<double>("TotalOrderPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            OrderDate = new DateTime(2022, 2, 4, 17, 47, 4, 475, DateTimeKind.Local).AddTicks(804),
                            Statu = 0,
                            TotalOrderPrice = 35.5,
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            OrderDate = new DateTime(2022, 2, 4, 17, 47, 4, 475, DateTimeKind.Local).AddTicks(2193),
                            Statu = 0,
                            TotalOrderPrice = 75.5,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.OrderLine", b =>
                {
                    b.Property<int>("OrderLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderLineId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");

                    b.HasData(
                        new
                        {
                            OrderLineId = 1,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            OrderLineId = 2,
                            OrderId = 1,
                            ProductId = 2,
                            Quantity = 1
                        },
                        new
                        {
                            OrderLineId = 3,
                            OrderId = 2,
                            ProductId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            OrderLineId = 4,
                            OrderId = 2,
                            ProductId = 4,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductImgUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            Price = 15.5,
                            ProductName = "Makarna"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Price = 20.0,
                            ProductName = "Yogurt"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            Price = 65.0,
                            ProductName = "Kazak"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            Price = 10.5,
                            ProductName = "Bere"
                        });
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RoleDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleDescription = "Admin Rolü",
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleDescription = "Kullanıcı Rolü",
                            RoleName = "Kullanıcı"
                        });
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.ShippingCompany", b =>
                {
                    b.Property<int>("ShippingCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ShippingCompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ShippingCompanyId");

                    b.ToTable("ShippingCompanies");

                    b.HasData(
                        new
                        {
                            ShippingCompanyId = 1,
                            ShippingCompanyName = "YurticiKargo"
                        },
                        new
                        {
                            ShippingCompanyId = 2,
                            ShippingCompanyName = "ArasKargo"
                        });
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "sinem@mail.com",
                            FirstName = "Sinem",
                            LastName = "Mutlu",
                            Password = "123456",
                            RoleId = 1,
                            UserName = "sinemmutlu"
                        });
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.Category", b =>
                {
                    b.HasOne("OrderAndShippingAPI.Entities.Concrete.ShippingCompany", "ShippingCompany")
                        .WithMany("Categories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShippingCompany");
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.Order", b =>
                {
                    b.HasOne("OrderAndShippingAPI.Entities.Concrete.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.OrderLine", b =>
                {
                    b.HasOne("OrderAndShippingAPI.Entities.Concrete.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderAndShippingAPI.Entities.Concrete.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.Product", b =>
                {
                    b.HasOne("OrderAndShippingAPI.Entities.Concrete.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.User", b =>
                {
                    b.HasOne("OrderAndShippingAPI.Entities.Concrete.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.Order", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.ShippingCompany", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("OrderAndShippingAPI.Entities.Concrete.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
