using Common.Models;
using Services.Interfaces;

namespace API.Endpoints;

public static class ProductEndpointExtensions
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/products");

        group.MapGet("", async (IProductService productService) =>
        {
            var products = await productService.GetAllProducts();
            return Results.Ok(products);
        });
        group.MapGet("/{id}", async (IProductService productService, int id) =>
        {
            var product = await productService.GetProductById(id);
            if (product == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(product);
        });
        group.MapGet("/name/{name}", async (IProductService productService, string name) =>
        {
            var product = await productService.GetProductByName(name);
            if (product == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(product);
        });
        group.MapPost("", async (IProductService productService, Product product) =>
        {
            await productService.AddProduct(product);
            return Results.Created($"/api/products/{product.Id}", product);
        });
        group.MapPut("{id}", async (IProductService productService, int id, Product product) =>
        {
            if (id != product.Id)
            {
                return Results.BadRequest("Product ID mismatch");
            }
            await productService.UpdateProduct(product);
            return Results.NoContent();
        });
        group.MapPut("{id}/{status}", async (IProductService productService, int id, bool status) =>
        {
            await productService.UpdateProductStatus(id, status);
            if (status)
            {
                return Results.Ok($"Product {id} is now in stock");
            }
            return Results.Ok($"Product {id} is now out of stock");
        });
        group.MapDelete("{id}", async (IProductService productService, int id) =>
        {
            await productService.DeleteProduct(id);
            return Results.NoContent();
        });
        group.MapPut("{productId}/category/{categoryId}",
            async (IProductService productService, int productId, int categoryId) =>
            {
                await productService.UpdateProductCategory(productId, categoryId);
                return Results.Ok($"Product {productId} now has category {categoryId}");
            });
        group.MapDelete("{productId}/category/{categoryId}",
            async (IProductService productService, int productId, int categoryId) =>
            {
                await productService.RemoveProductCategory(productId, categoryId);
                return Results.Ok($"Product {productId} now has no category");
            });
        return app;
    }
}