using DataAccess.Entities;

namespace Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product?> GetProductById(int id);
    Task<Product?> GetProductByName(string name);
    Task AddProduct(Product product);
    Task UpdateProduct(Product product);
    Task UpdateProductStatus(int id, bool status);
    Task DeleteProduct(int id);
    Task UpdateProductCategory(int productId, int categoryId);
    Task RemoveProductCategory(int productId, int categoryId);
}