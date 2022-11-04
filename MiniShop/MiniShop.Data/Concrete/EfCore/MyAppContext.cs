using Microsoft.EntityFrameworkCore;
using MiniShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Data.Concrete.EfCore
{
    public class MyAppContext : DbContext
    {
        
        public MyAppContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ProductCategory>()
                .HasKey(pc => new
                {
                    pc.ProductId,
                    pc.CategoryId
                });
            modelBuilder
                .Entity<Category>()
                .HasData(
                    new Category() { Id = 1, Name = "Phone", Description = "Phone Category", Url = "phone" },
                    new Category() { Id = 2, Name = "Computer", Description = "Computer Category", Url = "computer" },
                    new Category() { Id = 3, Name = "Electronic", Description = "Electronic Category", Url = "electronic" },
                    new Category() { Id = 4, Name = "Household Appliances", Description = "Household Appliances Category", Url = "household-appliances" }
                );

            modelBuilder
                .Entity<Product>()
                .HasData(
                    new Product() { Id = 1, Name = "IPhone 13", Properties = "128 Gb", Price = 24000, Url = "iphone-13", IsApproved = true, IsHome = true, ImageUrl = "1.png" },

                    new Product() { Id = 2, Name = "IPhone 13 Pro", Properties = "256 Gb", Price = 28000, Url = "iphone-13-pro", IsApproved = true, IsHome = true, ImageUrl = "2.png" },

                    new Product() { Id = 3, Name = "Samsung S21", Properties = "128 Gb", Price = 22000, Url = "samsung-s21", IsApproved = true, IsHome = true, ImageUrl = "3.png" },

                    new Product() { Id = 4, Name = "Vestel CM125", Properties = "Full Automatic Washing Machine", Price = 18000, Url = "vestel-cm-125", IsApproved = true, IsHome = false, ImageUrl = "4.png" },

                    new Product() { Id = 5, Name = "Arcelik TV-102 Smart TV", Properties = "102 inch smart tv", Price = 24000, Url = "arcelik-tv-102-smart-tv", IsApproved = true, IsHome = false, ImageUrl = "5.png" },

                    new Product() { Id = 6, Name = "LG TV-102 Smart TV", Properties = "102 inch smart tv", Price = 24000, Url = "lg-tv-102-smart-tv", IsApproved = false, IsHome = true, ImageUrl = "5.png" },

                    new Product() { Id = 7, Name = "Sony TV-102 Smart TV", Properties = "102 inch smart tv", Price = 24000, Url = "sony-tv-102-smart-tv", IsApproved = true, IsHome = false, ImageUrl = "5.png" },

                    new Product() { Id = 8, Name = "Arcelik TV-102 Smart TV", Properties = "102 inç smart tv", Price = 24000, Url = "arcelik-tv-102-smart-tv", IsApproved = true, IsHome = false, ImageUrl = "5.png" },

                    new Product() { Id = 9, Name = "Arcelik TV-102 Smart TV", Properties = "102 inç smart tv", Price = 24000, Url = "arcelik-tv-102-smart-tv", IsApproved = true, IsHome = false, ImageUrl = "5.png" },

                    new Product() { Id = 10, Name = "Arcelik TV-102 Smart TV", Properties = "102 inç smart tv", Price = 24000, Url = "arcelik-tv-102-smart-tv", IsApproved = true, IsHome = false, ImageUrl = "5.png" }

                );

            modelBuilder
                .Entity<ProductCategory>()
                .HasData(
                    new ProductCategory() { ProductId = 1, CategoryId = 1 },
                    new ProductCategory() { ProductId = 2, CategoryId = 1 },
                    new ProductCategory() { ProductId = 3, CategoryId = 1 },
                    new ProductCategory() { ProductId = 1, CategoryId = 3 },
                    new ProductCategory() { ProductId = 2, CategoryId = 3 },
                    new ProductCategory() { ProductId = 3, CategoryId = 3 },
                    new ProductCategory() { ProductId = 4, CategoryId = 3 },
                    new ProductCategory() { ProductId = 4, CategoryId = 4 },
                    new ProductCategory() { ProductId = 5, CategoryId = 3 },
                    new ProductCategory() { ProductId = 6, CategoryId = 3 },
                    new ProductCategory() { ProductId = 7, CategoryId = 3 },
                    new ProductCategory() { ProductId = 8, CategoryId = 3 },
                    new ProductCategory() { ProductId = 9, CategoryId = 3 },
                    new ProductCategory() { ProductId = 10, CategoryId = 3 }
                );

        }
    }
}
