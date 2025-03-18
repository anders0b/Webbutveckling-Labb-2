using Common.Models;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    private readonly BrodDbContext _dbContext;
    public CustomerRepository(BrodDbContext dbContext) : base(dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<Customer?> GetCustomerByEmail(string email)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }
    public async Task<IEnumerable<Customer>> GetCustomersByCity(string city)
    {
        var customers = _dbContext.Customers.Where(c => c.City == city);
        return customers;
    }

}