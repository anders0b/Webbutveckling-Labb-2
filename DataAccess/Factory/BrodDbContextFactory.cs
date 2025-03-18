using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Factory;

public class BrodDbContextFactory : IDesignTimeDbContextFactory<BrodDbContext>
{
    public BrodDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API"))
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<BrodDbContext>();
        var connectionString = configuration.GetConnectionString("AndersBrodDb");

        optionsBuilder.UseSqlServer(connectionString);

        return new BrodDbContext(optionsBuilder.Options);
    }
}
