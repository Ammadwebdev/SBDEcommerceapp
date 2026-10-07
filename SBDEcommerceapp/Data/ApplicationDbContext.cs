using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBDEcommerceapp.Models;

namespace SBDEcommerceapp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "Resolve", DisplayOrder = 1 },

                new Category { Id = 2, Name = "Nova", DisplayOrder = 2 },

                new Category { Id = 3, Name = "Forge", DisplayOrder = 3 }

            );

            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 1,
                    Title = "SBD Resolve Socks",
                    Author = "SBD",
                    Description = "High-performance training socks designed for comfort, durability, and support during intense workouts.",
                    SKU = "SBD-SOCK-001",
                    ListPrice = 60,
                    Price = 50,
                    Price50 = 45,
                    Price100 = 40
                },

                new Product
                {
                    Id = 2,
                    Title = "SBD Nova Lifting Straps",
                    Author = "SBD",
                    Description = "Heavy-duty lifting straps designed to improve grip and support during deadlifts and pulling exercises.",
                    SKU = "SBD-STRAP-002",
                    ListPrice = 180,
                    Price = 160,
                    Price50 = 150,
                    Price100 = 140
                },

                new Product
                {
                    Id = 3,
                    Title = "SBD Forge T-Shirt Standard",
                    Author = "SBD",
                    Description = "Comfortable and durable training t-shirt made with breathable fabric for everyday workouts.",
                    SKU = "SBD-TSHIRT-003",
                    ListPrice = 120,
                    Price = 100,
                    Price50 = 90,
                    Price100 = 80
                },

                new Product
                {
                    Id = 4,
                    Title = "SBD Forge Hoodie",
                    Author = "SBD",
                    Description = "Premium heavyweight hoodie designed for warmth, comfort, and durability during training or casual wear.",
                    SKU = "SBD-HOODIE-004",
                    ListPrice = 300,
                    Price = 270,
                    Price50 = 250,
                    Price100 = 230
                },

                new Product
                {
                    Id = 5,
                    Title = "SBD Forge Sweatshirt",
                    Author = "SBD",
                    Description = "Soft and durable sweatshirt ideal for training sessions and everyday use.",
                    SKU = "SBD-SWEAT-005",
                    ListPrice = 250,
                    Price = 220,
                    Price50 = 200,
                    Price100 = 180
                },

                new Product
                {
                    Id = 6,
                    Title = "SBD Nova Joggers",
                    Author = "SBD",
                    Description = "Athletic joggers designed for flexibility, comfort, and performance in and out of the gym.",
                    SKU = "SBD-JOGGER-006",
                    ListPrice = 200,
                    Price = 180,
                    Price50 = 160,
                    Price100 = 150
                },

                new Product
                {
                    Id = 7,
                    Title = "SBD Resolve Weightlifting T-Shirt",
                    Author = "SBD",
                    Description = "High-performance weightlifting t-shirt built for durability and comfort during heavy training.",
                    SKU = "SBD-TSHIRT-007",
                    ListPrice = 130,
                    Price = 110,
                    Price50 = 100,
                    Price100 = 90
                }

            );
        }
    }
}