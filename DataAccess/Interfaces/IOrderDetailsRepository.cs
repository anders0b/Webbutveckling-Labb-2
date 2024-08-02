using DataAccess.Entities;

namespace DataAccess.Interfaces;

public interface IOrderDetailsRepository : IRepository<OrderDetails>
{
    Task DeleteOrderDetails(int orderId, int productId);
    Task UpdateProductQuantity(int orderId, int productId, int quantity);
}