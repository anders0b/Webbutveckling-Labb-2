using Common.Models;

namespace Services.Interfaces;

public interface IOrderDetailsService
{
    Task<IEnumerable<OrderDetails>> GetAllOrderDetails();
    Task AddOrderDetails(OrderDetails orderDetails);
    Task DeleteOrderDetails(int orderId, int productId);
    Task UpdateProductQuantity(int orderId, int productId, int quantity);
}