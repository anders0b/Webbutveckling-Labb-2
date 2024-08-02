using Common.Models;

namespace FrontEnd.Services;

public class OrderService
{
    private readonly HttpClient _httpClient;
    public OrderService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }
    public async Task<IEnumerable<OrderModel>> GetAllOrders()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<OrderModel>>("api/orders");
    }
    public async Task<OrderModel?> GetOrderById(int id)
    {
        return await _httpClient.GetFromJsonAsync<OrderModel>($"api/orders/{id}");
    }
    public async Task AddOrder(OrderModel order)
    {
        await _httpClient.PostAsJsonAsync("api/orders", order);
    }
    public async Task UpdateOrder(OrderModel order)
    {
        await _httpClient.PutAsJsonAsync($"api/orders/{order.Id}", order);
    }
    public async Task DeleteOrder(int id)
    {
        await _httpClient.DeleteAsync($"api/orders/{id}");
    }
    public async Task UpdateOrderIsShipped(int id, bool status)
    {
        await _httpClient.PutAsJsonAsync($"api/orders/{id}/{status}", status);
    }
    public async Task<IEnumerable<OrderModel>> GetAllOrdersAndOrderDetails()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<OrderModel>>("api/orders/orderdetails");
    }
}