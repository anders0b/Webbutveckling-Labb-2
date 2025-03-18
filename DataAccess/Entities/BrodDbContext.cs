using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public class BrodDbContext(DbContextOptions<BrodDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetails>()
            .HasKey(oi => new { oi.OrderId, oi.ProductId });
    }
}

