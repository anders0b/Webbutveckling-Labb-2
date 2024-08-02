using DataAccess.Entities;
using DataAccess.Interfaces;
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
        group.MapGet("{id}", async (ICategoryService categoryService, int id) =>
        {
            var category = await categoryService.GetCategoryById(id);
            if (category == null)
            {
                return Results.NotFound("Id not found");
            }
            return Results.Ok(category);
        });
        group.MapPost("", async (ICategoryService categoryService, Category category) =>
        {
            await categoryService.CreateCategory(category);
            return Results.Created($"/api/categories/{category.Id}", category);
        });
        group.MapDelete("{id}", async (ICategoryService categoryService, int id) =>
        {
            await categoryService.DeleteCategory(id);
            return Results.NoContent();
        });
        return app;
    }
}