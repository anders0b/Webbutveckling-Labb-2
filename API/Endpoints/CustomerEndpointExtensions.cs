using DataAccess.Entities;
using DataAccess.Interfaces;
using Services.Interfaces;

namespace API.Endpoints;

public static class CustomerEndpointExtensions
{
    public static IEndpointRouteBuilder MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/customers");

        group.MapGet("", async (ICustomerService customerService) =>
        {
            var customers = await customerService.GetAllCustomers();
            return Results.Ok(customers);
        });
        group.MapGet("{id}", async (ICustomerService customerService, int id) =>
        {
            var customer = await customerService.GetCustomerById(id);
            if (customer == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(customer);
        });
        group.MapGet("/email/{email}", async (ICustomerService customerService, string email) =>
        {
            var customer = await customerService.GetCustomerByEmail(email);
            if (customer == null)
            {
                return Results.NotFound($"No customer with email {email} exists");
            }
            return Results.Ok(customer);
        });
        group.MapGet("/city/{city}", async (ICustomerService customerService, string city) =>
        {
            var customers = await customerService.GetCustomersByCity(city);
            return Results.Ok(customers);
        });
        group.MapPost("", async (ICustomerService customerService, Customer customer) =>
        {
            await customerService.AddCustomer(customer);
            return Results.Created($"/api/customers/{customer.Id}", customer);
        });
        group.MapPut("{id}", async (ICustomerService customerService, int id, Customer customer) =>
        {
            if (id != customer.Id)
            {
                return Results.BadRequest("Customer ID mismatch");
            }
            await customerService.UpdateCustomer(customer);
            return Results.NoContent();
        });
        group.MapDelete("{id}", async (ICustomerService customerService, int id) =>
        {
            await customerService.DeleteCustomer(id);
            return Results.NoContent();
        });
        return app;
    }
}