using Microsoft.EntityFrameworkCore;
using WarehouseApp.Models;

namespace WarehouseApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Электроника" },
                new Category { Id = 2, Name = "Одежда" },
                new Category { Id = 3, Name = "Продукты" },
                new Category { Id = 4, Name = "КГТ" }
            );
        }
    }
}