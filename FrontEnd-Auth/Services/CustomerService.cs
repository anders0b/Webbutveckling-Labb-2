using Common.Models;

namespace FrontEnd.Services;

public class CustomerService
{
    private readonly HttpClient _httpClient;
    public CustomerService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }
    public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerModel>>("api/customers");
    }
    public async Task AddCustomer(CustomerModel customer)
    {
        await _httpClient.PostAsJsonAsync("api/customers", customer);
    }
    public async Task DeleteCustomer(int customerId)
    {
        await _httpClient.DeleteAsync($"api/customers/{customerId}");
    }
    public async Task UpdateCustomer(CustomerModel customer)
    {
        await _httpClient.PutAsJsonAsync($"api/customers/{customer.Id}", customer);
    }
    public async Task<CustomerModel> GetCustomerById(int customerId)
    {
        return await _httpClient.GetFromJsonAsync<CustomerModel>($"api/customers/{customerId}");
    }
    public async Task<IEnumerable<CustomerModel>> GetCustomersByCity(string city)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerModel>>($"api/customers/city/{city}");
    }
    public async Task<CustomerModel> GetCustomerByEmail(string email)
    {
        return await _httpClient.GetFromJsonAsync<CustomerModel>($"api/customers/email/{email}");
    }
}