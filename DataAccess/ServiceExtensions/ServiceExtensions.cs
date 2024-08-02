using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.ServiceExtensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddAndersBrodContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AndersBrodContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("AndersBrodDb"));
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();

        return services;
    }
}