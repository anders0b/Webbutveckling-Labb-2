using DataAccess.Entities;

namespace DataAccess.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetCustomerByEmail(string email);
    Task<IEnumerable<Customer>> GetCustomersByCity(string city);
}