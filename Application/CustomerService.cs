using Common.Models;
using DataAccess.Interfaces;
using Services.Interfaces;

namespace Services;

public class CustomerService(IUnitOfWork unitOfWork) : ICustomerService
{
    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        var customers = await unitOfWork.Customers.GetAll();
        return customers;
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        var customer = await unitOfWork.Customers.GetById(id);
        return customer;
    }

    public async Task<Customer?> GetCustomerByEmail(string email)
    {
        var customer = await unitOfWork.Customers.GetCustomerByEmail(email);
        return customer;
    }

    public async Task<IEnumerable<Customer>> GetCustomersByCity(string city)
    {
        var customers = await unitOfWork.Customers.GetCustomersByCity(city);
        return customers;
    }

    public async Task AddCustomer(Customer customer)
    {
        var existingCustomer = await unitOfWork.Customers.GetCustomerByEmail(customer.Email);
        if (existingCustomer == null)
        {
            await unitOfWork.Customers.Add(customer);
            unitOfWork.Commit();
        }
    }
    public async Task UpdateCustomer(Customer customer)
    {
        var customerToUpdate = await unitOfWork.Customers.GetById(customer.Id);
        if (customerToUpdate != null)
        {
            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.Email = customer.Email;
            customerToUpdate.Phone = customer.Phone;
            customerToUpdate.StreetAddress = customer.StreetAddress;
            customerToUpdate.PostalCode = customer.PostalCode;
            customerToUpdate.City = customer.City;
            customerToUpdate.Orders = customer.Orders;
            await unitOfWork.Customers.Update(customerToUpdate);
            unitOfWork.Commit();
        }
    }
    public async Task DeleteCustomer(int id)
    {
        var customer = await unitOfWork.Customers.GetById(id);
        if (customer != null)
        {
            await unitOfWork.Customers.Delete(customer);
            unitOfWork.Commit();
        }
    }
}