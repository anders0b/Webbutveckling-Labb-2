using DataAccess.Entities;

namespace DataAccess.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    ICustomerRepository Customers { get; }
    ICategoryRepository Categories { get; }
    IOrderRepository Orders { get; }
    IOrderDetailsRepository OrderDetails { get; }
    void Commit();
    void Rollback();
}