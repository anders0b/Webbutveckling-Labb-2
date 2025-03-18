using Common.Models;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess;

public class ProductRepository(BrodDbContext dbContext) : Repository<Product>(dbContext), IProductRepository
{
    private readonly BrodDbContext _dbContext = dbContext;

    public async Task<Product?> GetProductByName(string name)
    {
        return await _dbContext.Products.FindAsync(name);
    }

    public async Task UpdateProductStatus(int id, bool status)
    {
        var product = await _dbContext.Products.FindAsync(id);
        product.Status = status;
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateProductCategory(int productId, int categoryId)
    {
        var product = await _dbContext.Products.FindAsync(productId);
        product.CategoryId = categoryId;
        await _dbContext.SaveChangesAsync();
    }
    public async Task RemoveProductCategory(int productId, int categoryId)
    {
        var product = await _dbContext.Products.FindAsync(productId);
        product.CategoryId = 0;
        await _dbContext.SaveChangesAsync();
    }
}