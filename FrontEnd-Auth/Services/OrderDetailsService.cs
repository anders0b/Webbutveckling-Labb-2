using Common.Models;

namespace FrontEnd.Services;

public class OrderDetailsService
{
    private readonly HttpClient _httpClient;
    public OrderDetailsService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }
    public async Task<IEnumerable<OrderDetailsModel>> GetAllOrderDetails()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<OrderDetailsModel>>("api/orderdetails");
    }
    public async Task OrderDetailsByOrderId(int orderId)
    {
        await _httpClient.GetFromJsonAsync<IEnumerable<OrderDetailsModel>>($"api/orderdetails/{orderId}");
    }
    public async Task AddOrderDetails(OrderDetailsModel orderDetails)
    {
        await _httpClient.PostAsJsonAsync("api/orderdetails", orderDetails);
    }
    public async Task DeleteOrderDetails(int orderId, int productId)
    {
        await _httpClient.DeleteAsync($"api/orderdetails/{orderId}/{productId}");
    }
    public async Task UpdateProductQuantity(int orderId, int productId, int quantity)
    {
        await _httpClient.PutAsJsonAsync($"api/orderdetails/{orderId}/{productId}/{quantity}", quantity);
    }

}