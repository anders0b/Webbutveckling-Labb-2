using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly AndersBrodContext _context;
    public UnitOfWork(AndersBrodContext context)
    {
        _context = context;
        Products = new ProductRepository(_context);
        Customers = new CustomerRepository(_context);
        Categories = new CategoryRepository(_context);
        Orders = new OrderRepository(_context);
        OrderDetails = new OrderDetailsRepository(_context);
    }
    public IProductRepository Products { get; }
    public ICustomerRepository Customers { get; }
    public ICategoryRepository Categories { get; }
    public IOrderRepository Orders { get; }
    public IOrderDetailsRepository OrderDetails { get; }

    public void Commit()
    {
        _context.SaveChanges();
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
            _context.Dispose();
        }
    }
}