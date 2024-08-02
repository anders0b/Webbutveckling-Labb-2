using System.ComponentModel.DataAnnotations;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly AndersBrodContext _context;

    public OrderRepository(AndersBrodContext context) : base(context)
    {
        _context = context;
    }
    public async Task UpdateOrderIsShipped(int id, bool isShipped)
    {
        var order = await _context.Orders.FindAsync(id);
        order.IsShipped = isShipped;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAndOrderDetails()
    {
        var orders = await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
        return orders;
    }

}