using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BigShope.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed initial data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics", Description = "Electronic devices and gadgets", IsActive = true },
                new Category { CategoryId = 2, Name = "Fashion", Description = "Clothing and accessories", IsActive = true },
                new Category { CategoryId = 3, Name = "Home & Garden", Description = "Home decor and garden items", IsActive = true },
                new Category { CategoryId = 4, Name = "Sports", Description = "Sports equipment and accessories", IsActive = true },
                new Category { CategoryId = 5, Name = "Books", Description = "Books and educational materials", IsActive = true }
            );

            modelBuilder.Entity<Product>().HasData(
                // New Products
                new Product { ProductId = 1, CategoryId = 1, Name = "Smartphone X", Description = "Latest smartphone with advanced features", Price = 999.99m, ImageUrl = "/images/si1.jpg", StockQuantity = 50, IsNew = true, IsActive = true },
                new Product { ProductId = 2, CategoryId = 2, Name = "Designer Bag", Description = "Elegant designer handbag", Price = 299.99m, ImageUrl = "/images/ba.jpg", StockQuantity = 30, IsNew = true, IsActive = true },
                new Product { ProductId = 3, CategoryId = 3, Name = "Modern Lamp", Description = "Contemporary desk lamp", Price = 89.99m, ImageUrl = "/images/pic.jpg", StockQuantity = 40, IsNew = true, IsActive = true },
                new Product { ProductId = 4, CategoryId = 4, Name = "Yoga Mat", Description = "Premium yoga mat for exercise", Price = 49.99m, ImageUrl = "/images/s1.jpg", StockQuantity = 100, IsNew = true, IsActive = true },
                
                // Promotional Products
                new Product { ProductId = 5, CategoryId = 1, Name = "Laptop Pro", Description = "High-performance laptop", Price = 1499.99m, PromotionalPrice = 1199.99m, ImageUrl = "/images/si2.jpg", StockQuantity = 25, IsPromotion = true, IsActive = true },
                new Product { ProductId = 6, CategoryId = 2, Name = "Winter Jacket", Description = "Warm winter jacket", Price = 199.99m, PromotionalPrice = 149.99m, ImageUrl = "/images/pic2.jpg", StockQuantity = 60, IsPromotion = true, IsActive = true },
                new Product { ProductId = 7, CategoryId = 3, Name = "Coffee Maker", Description = "Automatic coffee machine", Price = 249.99m, PromotionalPrice = 199.99m, ImageUrl = "/images/bott.jpg", StockQuantity = 35, IsPromotion = true, IsActive = true },
                new Product { ProductId = 8, CategoryId = 5, Name = "Programming Guide", Description = "Complete programming tutorial", Price = 59.99m, PromotionalPrice = 39.99m, ImageUrl = "/images/pic3.jpg", StockQuantity = 80, IsPromotion = true, IsActive = true }
            );
        }
    }
}
