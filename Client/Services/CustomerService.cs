using Common.Models;

namespace FrontEnd.Services;

public class CustomerService
{
    private readonly HttpClient _httpClient;
    public CustomerService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }
    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("api/customers");
    }
    public async Task AddCustomer(Customer customer)
    {
        await _httpClient.PostAsJsonAsync("api/customers", customer);
    }
    public async Task DeleteCustomer(int customerId)
    {
        await _httpClient.DeleteAsync($"api/customers/{customerId}");
    }
    public async Task UpdateCustomer(Customer customer)
    {
        await _httpClient.PutAsJsonAsync($"api/customers/{customer.Id}", customer);
    }
    public async Task<Customer> GetCustomerById(int customerId)
    {
        return await _httpClient.GetFromJsonAsync<Customer>($"api/customers/{customerId}");
    }
    public async Task<IEnumerable<Customer>> GetCustomersByCity(string city)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>($"api/customers/city/{city}");
    }
    public async Task<Customer> GetCustomerByEmail(string email)
    {
        return await _httpClient.GetFromJsonAsync<Customer>($"api/customers/email/{email}");
    }
}