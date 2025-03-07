using Common.Models;

namespace Services.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomers();
    Task<Customer?> GetCustomerById(int id);
    Task<Customer?> GetCustomerByEmail(string email);
    Task<IEnumerable<Customer>> GetCustomersByCity(string city);
    Task AddCustomer(Customer customer);
    Task UpdateCustomer(Customer customer);
    Task DeleteCustomer(int id);
}