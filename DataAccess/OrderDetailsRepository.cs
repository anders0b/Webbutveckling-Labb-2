using Common.Models;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess;

public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
{
    private readonly BrodDbContext _dbContext;
    public OrderDetailsRepository(BrodDbContext dbContext) : base(dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task DeleteOrderDetails(int orderId, int productId)
    {
        var orderDetail = await _dbContext.OrderDetails.FindAsync(orderId, productId);
        _dbContext.OrderDetails.Remove(orderDetail);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateProductQuantity(int orderId, int productId, int quantity)
    {
        var orderDetail = await _dbContext.OrderDetails.FindAsync(orderId, productId);
        orderDetail.Quantity = quantity;
        await _dbContext.SaveChangesAsync();
    }
}