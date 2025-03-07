using Common.Models;

namespace DataAccess.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetProductByName(string name);
    Task UpdateProductStatus(int id, bool status);
    Task UpdateProductCategory(int productId, int categoryId);
    Task RemoveProductCategory(int productId, int categoryId);
}