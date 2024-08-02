using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly AndersBrodContext context;
    public ProductRepository(AndersBrodContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<Product?> GetProductByName(string name)
    {
        return await context.Products.FindAsync(name);
    }

    public async Task UpdateProductStatus(int id, bool status)
    {
        var product = await context.Products.FindAsync(id);
        product.Status = status;
        await context.SaveChangesAsync();
    }

    public async Task UpdateProductCategory(int productId, int categoryId)
    {
        var product = await context.Products.FindAsync(productId);
        product.CategoryId = categoryId;
        await context.SaveChangesAsync();
    }
    public async Task RemoveProductCategory(int productId, int categoryId)
    {
        var product = await context.Products.FindAsync(productId);
        product.CategoryId = 0;
        await context.SaveChangesAsync();
    }
}