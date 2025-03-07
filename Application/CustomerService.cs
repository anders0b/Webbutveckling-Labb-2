using Common.Models;
using DataAccess.Interfaces;
using Services.Interfaces;

namespace Services;

public class CustomerService : ICustomerService
{
    public IUnitOfWork _unitOfWork;
    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        var customers = await _unitOfWork.Customers.GetAll();
        return customers;
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        var customer = await _unitOfWork.Customers.GetById(id);
        if (customer != null)
        {
            return customer;
        }
        return null;
    }

    public async Task<Customer?> GetCustomerByEmail(string email)
    {
        var customer = await _unitOfWork.Customers.GetCustomerByEmail(email);
        if (customer != null)
        {
            return customer;
        }
        return null;
    }

    public async Task<IEnumerable<Customer>> GetCustomersByCity(string city)
    {
        var customers = await _unitOfWork.Customers.GetCustomersByCity(city);
        return customers;
    }

    public async Task AddCustomer(Customer customer)
    {
        var existingCustomer = await _unitOfWork.Customers.GetCustomerByEmail(customer.Email);
        if (existingCustomer == null)
        {
            await _unitOfWork.Customers.Add(customer);
            _unitOfWork.Commit();
        }
    }
    public async Task UpdateCustomer(Customer customer)
    {
        var customerToUpdate = await _unitOfWork.Customers.GetById(customer.Id);
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
            await _unitOfWork.Customers.Update(customerToUpdate);
            _unitOfWork.Commit();
        }
    }
    public async Task DeleteCustomer(int id)
    {
        var customer = await _unitOfWork.Customers.GetById(id);
        if (customer != null)
        {
            await _unitOfWork.Customers.Delete(customer);
            _unitOfWork.Commit();
        }
    }
}