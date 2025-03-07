using Common.Models;
using DataAccess.Interfaces;
using Services.Interfaces;

namespace Services;

public class ProductService : IProductService
{
    public IUnitOfWork _unitOfWork;
    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        var products = await _unitOfWork.Products.GetAll();
        return products;
    }

    public async Task<Product?> GetProductById(int id)
    {
        if (id <= 0) return null;
        var product = await _unitOfWork.Products.GetById(id);
        if (product != null)
        {
            return product;
        }
        return null;
    }

    public async Task<Product?> GetProductByName(string name)
    {
        if (string.IsNullOrEmpty(name)) return null;
        var product = await _unitOfWork.Products.GetProductByName(name);
        if (product != null)
        {
            return product;
        }
        return null;
    }

    public async Task AddProduct(Product product)
    {
        await _unitOfWork.Products.Add(product);
        _unitOfWork.Commit();
    }

    public async Task UpdateProduct(Product product)
    {
        await _unitOfWork.Products.Update(product);
        _unitOfWork.Commit();
    }

    public async Task UpdateProductStatus(int id, bool status)
    {
        var product = await _unitOfWork.Products.GetById(id);
        if (product != null)
        {
            product.Status = status;
            await _unitOfWork.Products.Update(product);
            _unitOfWork.Commit();
        }
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _unitOfWork.Products.GetById(id);
        if (product != null)
        {
            await _unitOfWork.Products.Delete(product);
            _unitOfWork.Commit();
        }
    }

    public async Task UpdateProductCategory(int productId, int categoryId)
    {
        var product = await _unitOfWork.Products.GetById(productId);
        var category = await _unitOfWork.Categories.GetById(categoryId);
        if (product != null && category != null)
        {
            product.CategoryId = categoryId;
            await _unitOfWork.Products.Update(product);
            _unitOfWork.Commit();
        }
    }

    public async Task RemoveProductCategory(int productId, int categoryId)
    {
        var product = await _unitOfWork.Products.GetById(productId);
        var category = await _unitOfWork.Categories.GetById(categoryId);
        if (product != null && category != null)
        {
            product.CategoryId = 0;
            await _unitOfWork.Products.Update(product);
            _unitOfWork.Commit();
        }
    }
}