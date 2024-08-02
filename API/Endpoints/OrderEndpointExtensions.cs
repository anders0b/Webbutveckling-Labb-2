using DataAccess.Entities;
using DataAccess.Interfaces;
using Services.Interfaces;

namespace API.Endpoints;

public static class OrderEndpointExtensions
{
    public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/orders");

        group.MapGet("", async (IOrderService orderService) =>
        {
            var orders = await orderService.GetAllOrders();
            return Results.Ok(orders);
        });
        group.MapGet("{id}", async (IOrderService orderService, int id) =>
        {
            var order = await orderService.GetOrderById(id);
            if (order == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(order);
        });
        group.MapPost("", async (IOrderService orderService, Order order) =>
        {
            await orderService.AddOrder(order);
            return Results.Created($"/api/orders/{order.Id}", order);
        });
        group.MapPut("{id}", async (IOrderService orderService, int id, Order order) =>
        {
            if (id != order.Id)
            {
                return Results.BadRequest("Order ID mismatch");
            }
            await orderService.UpdateOrder(order);
            return Results.NoContent();
        });
        group.MapDelete("{id}", async (IOrderService orderService, int id) =>
        {
            await orderService.DeleteOrder(id);
            return Results.NoContent();
        });
        group.MapPut("{id}/{status}", async (IOrderService orderService, int id, bool status) =>
        {
            await orderService.UpdateOrderIsShipped(id, status);
            if (status)
            {
                return Results.Ok($"Order {id} has been shipped");
            }
            return Results.Ok($"Order {id} has not been shipped");
        });
        group.MapGet("orderdetails", async (IOrderService orderService) =>
        {
            var orders = await orderService.GetAllOrdersAndOrderDetails();
            return Results.Ok(orders);
        });
        return app;
    }
}