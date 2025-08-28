using Microsoft.EntityFrameworkCore;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Domain.ValueObjects;

namespace MinimalAPI.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasConversion(
                    v => v.Value,
                    v => new ProductName(v));

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasConversion(
                    v => v.Value,
                    v => new ProductDescription(v));

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasConversion(
                    v => v.Value,
                    v => new ProductPrice(v));
        }
    }
}
