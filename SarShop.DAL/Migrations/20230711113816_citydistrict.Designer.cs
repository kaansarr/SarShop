﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SarShop.DAL.Contexts;

#nullable disable

namespace SarShop.DAL.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20230711113816_citydistrict")]
    partial class citydistrict
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SarShop.DAL.Entities.Aboutt", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasMaxLength(2147483647)
                        .HasColumnType("varchar(MAX)");

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.ToTable("About");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Password")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Kaan",
                            Password = "202cb962ac59075b964b07152d234b70",
                            Surname = "Sar",
                            UserName = "kaan"
                        });
                });

            modelBuilder.Entity("SarShop.DAL.Entities.Brand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.District", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("District");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("BrandID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Detail")
                        .HasColumnType("text");

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("ProductID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.ProductPicture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Picture")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductPicture");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.Slide", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Picture")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Slide");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.Category", b =>
                {
                    b.HasOne("SarShop.DAL.Entities.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentID");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.District", b =>
                {
                    b.HasOne("SarShop.DAL.Entities.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("City");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.Product", b =>
                {
                    b.HasOne("SarShop.DAL.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.ProductCategory", b =>
                {
                    b.HasOne("SarShop.DAL.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SarShop.DAL.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.ProductPicture", b =>
                {
                    b.HasOne("SarShop.DAL.Entities.Product", "Product")
                        .WithMany("ProductPictures")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.Category", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("SarShop.DAL.Entities.Product", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ProductPictures");
                });
#pragma warning restore 612, 618
        }
    }
}
