using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    private readonly AndersBrodContext context;
    public CustomerRepository(AndersBrodContext context) : base(context)
    {
        this.context = context;
    }
    public async Task<Customer?> GetCustomerByEmail(string email)
    {
        return await context.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }
    public async Task<IEnumerable<Customer>> GetCustomersByCity(string city)
    {
        var customers = context.Customers.Where(c => c.City == city);
        return customers;
    }

}