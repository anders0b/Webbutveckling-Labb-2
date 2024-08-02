using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public class AndersBrodContext : DbContext
{ 
    public AndersBrodContext() {}
    public AndersBrodContext(DbContextOptions<AndersBrodContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=Talos; Initial Catalog=AndersBrodDb; Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetails>()
            .HasKey(oi => new { oi.OrderId, oi.ProductId });

    }
}

