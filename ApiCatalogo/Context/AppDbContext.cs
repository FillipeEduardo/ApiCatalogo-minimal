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
}
