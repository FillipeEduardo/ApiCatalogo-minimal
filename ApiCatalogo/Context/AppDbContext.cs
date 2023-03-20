using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Context;

public class AppDbContext : DbContext
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Category>().HasKey(x => x.CategoryId);
        mb.Entity<Category>().Property(x => x.Name).HasMaxLength(100).IsRequired();
        mb.Entity<Category>().Property(x => x.Description).HasMaxLength(150).IsRequired();

        mb.Entity<Product>().HasKey(x => x.ProductId);
        mb.Entity<Product>().Property(x => x.Name).HasMaxLength(100).IsRequired();
        mb.Entity<Product>().Property(x => x.Description).HasMaxLength(150);
        mb.Entity<Product>().Property(x => x.Image).HasMaxLength(100);
        mb.Entity<Product>().Property(x => x.Price).HasPrecision(14, 2);

        mb.Entity<Product>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);
    }
}
