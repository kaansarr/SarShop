﻿using Microsoft.EntityFrameworkCore;
using SarShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarShop.DAL.Contexts
{
    public class SqlContext:DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        { }
        public DbSet<Slide> Slide { get; set; }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPicture> ProductPicture { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
       
       
     
       
      
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Product>().HasOne(x=>x.Brand).WithMany(x=>x.Products).OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.ProductID, x.CategoryID });


            modelBuilder.Entity<Category>().HasOne(x=>x.ParentCategory).WithMany(x=>x.SubCategories).HasForeignKey(x=>x.ParentID);


            modelBuilder.Entity<Admin>().HasData(new Admin { ID = 1, Name = "Kaan", Surname = "Sar", UserName = "kaan", Password = "202cb962ac59075b964b07152d234b70" });

        }
    }
}
