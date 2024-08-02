using Common.Models;

namespace FrontEnd.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;
    public ProductService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }
    public async Task<IEnumerable<ProductModel>> GetAllProducts()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>("api/products");
    }
    public async Task AddProduct(ProductModel product)
    {
        await _httpClient.PostAsJsonAsync("api/products", product);
    }
    public async Task DeleteProduct(int productId)
    {
        await _httpClient.DeleteAsync($"api/products/{productId}");
    }
    public async Task UpdateProduct(ProductModel product)
    {
        await _httpClient.PutAsJsonAsync($"api/products/{product.Id}", product);
    }
    public async Task<ProductModel> GetProductById(int productId)
    {
        return await _httpClient.GetFromJsonAsync<ProductModel>($"api/products/{productId}");
    }
    public async Task UpdateProductStatus(int productId, bool status)
    {
        await _httpClient.PutAsJsonAsync($"api/products/{productId}/{status}", status);
    }
    public async Task<ProductModel> GetProductByName(string name)
    {
        return await _httpClient.GetFromJsonAsync<ProductModel>($"api/products/name/{name}");
    }
    public async Task UpdateProductCategory(int productId, int categoryId)
    {
        await _httpClient.GetFromJsonAsync<ProductModel>($"api/products/{productId}/category/{categoryId}");
    }
    public async Task RemoveProductCategory(int productId, int categoryId)
    {
        await _httpClient.GetFromJsonAsync<ProductModel>($"api/products/{productId}/category/{categoryId}");
    }

}