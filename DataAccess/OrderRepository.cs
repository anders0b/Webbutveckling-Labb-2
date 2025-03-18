using Common.Models;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly BrodDbContext _dbContext;

    public OrderRepository(BrodDbContext dbContext) : base(dbContext) => _dbContext = dbContext;
    public async Task UpdateOrderIsShipped(int id, bool isShipped)
    {
        var order = await _dbContext.Orders.FindAsync(id);
        order.IsShipped = isShipped;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAndOrderDetails()
    {
        var orders = await _dbContext.Orders.Include(o => o.OrderDetails).ToListAsync();
        return orders;
    }

}