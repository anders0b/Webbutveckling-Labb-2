using DataAccess.Entities;

namespace Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrders();
    Task<Order?> GetOrderById(int id);
    Task AddOrder(Order order);
    Task UpdateOrder(Order order);
    Task DeleteOrder(int id);
    Task UpdateOrderIsShipped(int id, bool isShipped);
    Task<IEnumerable<Order>> GetAllOrdersAndOrderDetails();
}