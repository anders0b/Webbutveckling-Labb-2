using Common.Models;
using DataAccess.Interfaces;
using Services.Interfaces;

namespace Services;

public class OrderService : IOrderService
{
    public IUnitOfWork _unitOfWork;
    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        var orders = await _unitOfWork.Orders.GetAll();
        return orders;
    }

    public async Task<Order?> GetOrderById(int id)
    {
        var order = await _unitOfWork.Orders.GetById(id);
        if (order != null)
        {
            return order;
        }
        return null;
    }

    public async Task AddOrder(Order order)
    {
        await _unitOfWork.Orders.Add(order);
        _unitOfWork.Commit();
    }

    public async Task UpdateOrder(Order order)
    {
        var orderToUpdate = await _unitOfWork.Orders.GetById(order.Id);
        if (orderToUpdate != null)
        {
            orderToUpdate.CustomerId = order.CustomerId;
            orderToUpdate.OrderDate = order.OrderDate;
            orderToUpdate.IsShipped = order.IsShipped;
            orderToUpdate.OrderDetails = order.OrderDetails;
            await _unitOfWork.Orders.Update(orderToUpdate);
            _unitOfWork.Commit();
        }
    }

    public async Task DeleteOrder(int id)
    {
        var order = await _unitOfWork.Orders.GetById(id);
        if (order != null)
        {
            await _unitOfWork.Orders.Delete(order);
            _unitOfWork.Commit();
        }
    }

    public async Task UpdateOrderIsShipped(int id, bool isShipped)
    {
        var order = await _unitOfWork.Orders.GetById(id);
        if (order != null)
        {
            order.IsShipped = isShipped;
            await _unitOfWork.Orders.Update(order);
            _unitOfWork.Commit();
        }
    }
    public async Task<IEnumerable<Order>> GetAllOrdersAndOrderDetails()
    {
        var orders = await _unitOfWork.Orders.GetAllOrdersAndOrderDetails();
        return orders;
    }
}