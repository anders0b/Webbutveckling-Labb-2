using DataAccess.Entities;
using DataAccess.Interfaces;
using Services.Interfaces;

namespace Services;

public class OrderDetailsService : IOrderDetailsService
{
    public IUnitOfWork _unitOfWork;
    public OrderDetailsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<OrderDetails>> GetAllOrderDetails()
    {
        var orderDetails = await _unitOfWork.OrderDetails.GetAll();
        return orderDetails;
    }

    public async Task AddOrderDetails(OrderDetails orderDetails)
    {
        await _unitOfWork.OrderDetails.Add(orderDetails);
        _unitOfWork.Commit();
    }

    public async Task DeleteOrderDetails(int orderId, int productId)
    {
        await _unitOfWork.OrderDetails.DeleteOrderDetails(orderId, productId);
        _unitOfWork.Commit();
    }

    public async Task UpdateProductQuantity(int orderId, int productId, int quantity)
    {
        await _unitOfWork.OrderDetails.UpdateProductQuantity(orderId, productId, quantity);
        _unitOfWork.Commit();
    }
}