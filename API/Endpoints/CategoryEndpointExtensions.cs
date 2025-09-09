using Common.Models;
using Services.Interfaces;

namespace API.Endpoints;

public static class CategoryEndpointExtensions
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/categories");

        group.MapGet("", async (ICategoryService categoryService) =>
        {
            var categories = await categoryService.GetAllCategories();
            return Results.Ok(categories);
        });
        
        group.MapGet("{id:int}", async (ICategoryService categoryService, int id) =>
        {
            var category = await categoryService.GetCategoryById(id);
            return category == null ? Results.BadRequest("Id not found") : Results.Ok(category);
        });
        
        group.MapPost("", async (ICategoryService categoryService, Category category) =>
        {
            await categoryService.CreateCategory(category);
            return Results.Created($"/api/categories/{category.Id}", category);
        });
        
        group.MapDelete("{id:int}", async (ICategoryService categoryService, int id) =>
        {
            await categoryService.DeleteCategory(id);
            return Results.NoContent();
        });
        
        return app;
    }
}