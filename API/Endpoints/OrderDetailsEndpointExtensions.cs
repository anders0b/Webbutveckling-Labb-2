using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Endpoints;

public static class OrderDetailsEndpointExtensions
{
    public static IEndpointRouteBuilder MapOrderDetailsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/orderdetails");

        group.MapGet("", async ([FromServices]IOrderDetailsService orderDetailsService) =>
        {
            var orderDetails = await orderDetailsService.GetAllOrderDetails();
            return Results.Ok(orderDetails);
        });
        group.MapPost("", async ([FromServices]IOrderDetailsService orderDetailsService, [FromBody]OrderDetails orderDetails) =>
        {
            await orderDetailsService.AddOrderDetails(orderDetails);
            return Results.Created($"/api/orderdetails/{orderDetails.OrderId}/{orderDetails.ProductId}", orderDetails);
        });
        group.MapDelete("{orderId}/{productId}",
            async (IOrderDetailsService orderDetailsService, int orderId, int productId) =>
            {
            await orderDetailsService.DeleteOrderDetails(orderId, productId);
            return Results.NoContent();
        });
        group.MapPut("{orderId}/{productId}/{quantity}",
            async (IOrderDetailsService orderDetailsService, int orderId, int productId, int quantity) =>
            {
            await orderDetailsService.UpdateProductQuantity(orderId, productId, quantity);
            return Results.Ok($"Product with Id {productId} now has a quantity of {quantity} in this order");
        });
        return app;
    }
}