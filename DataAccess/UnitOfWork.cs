using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly BrodDbContext _dbContext;
    public UnitOfWork(BrodDbContext dbContext)
    {
        _dbContext = dbContext;
        Products = new ProductRepository(_dbContext);
        Customers = new CustomerRepository(_dbContext);
        Categories = new CategoryRepository(_dbContext);
        Orders = new OrderRepository(_dbContext);
        OrderDetails = new OrderDetailsRepository(_dbContext);
    }
    public IProductRepository Products { get; }
    public ICustomerRepository Customers { get; }
    public ICategoryRepository Categories { get; }
    public IOrderRepository Orders { get; }
    public IOrderDetailsRepository OrderDetails { get; }

    public void Commit()
    {
        _dbContext.SaveChanges();
    }
    public void Rollback()
    {

    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}