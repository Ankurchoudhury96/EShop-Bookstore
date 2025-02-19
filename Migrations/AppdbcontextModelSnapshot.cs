﻿// <auto-generated />
using System;
using EShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EShop.Migrations
{
    [DbContext(typeof(Appdbcontext))]
    partial class AppdbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EShop.Models.Adminlogin", b =>
                {
                    b.Property<string>("AdminEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Adminname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminEmail");

                    b.ToTable("Adminlogins");
                });

            modelBuilder.Entity("EShop.Models.Category", b =>
                {
                    b.Property<int>("Cid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cid"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Cid");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Cid = 1,
                            CategoryName = "Phones"
                        },
                        new
                        {
                            Cid = 2,
                            CategoryName = "Laptops"
                        });
                });

            modelBuilder.Entity("EShop.Models.Order", b =>
                {
                    b.Property<int>("Orderid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Orderid"));

                    b.Property<DateTime?>("DateofPurchase")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Productid")
                        .HasColumnType("int");

                    b.Property<string>("Productname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Useremail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Orderid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EShop.Models.Product", b =>
                {
                    b.Property<int?>("Pid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Pid"));

                    b.Property<int?>("Cid")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ppic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.HasKey("Pid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EShop.Models.Registration", b =>
                {
                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EmailAddress");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("EShop.Models.Useraddress", b =>
                {
                    b.Property<string>("UName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Addressline1")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Addressline2")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Mobileno")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UName");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
