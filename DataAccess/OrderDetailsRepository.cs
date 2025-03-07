using Common.Models;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess;

public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
{
    private readonly AndersBrodContext context;
    public OrderDetailsRepository(AndersBrodContext context) : base(context)
    {
        this.context = context;
    }
    public async Task DeleteOrderDetails(int orderId, int productId)
    {
        var orderDetail = await context.OrderDetails.FindAsync(orderId, productId);
        context.OrderDetails.Remove(orderDetail);
        await context.SaveChangesAsync();
    }
    public async Task UpdateProductQuantity(int orderId, int productId, int quantity)
    {
        var orderDetail = await context.OrderDetails.FindAsync(orderId, productId);
        orderDetail.Quantity = quantity;
        await context.SaveChangesAsync();
    }
}