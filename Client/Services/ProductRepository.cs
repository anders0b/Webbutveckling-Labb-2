using Common.Models;

namespace FrontEnd.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;
    public ProductService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/products");
    }
    public async Task AddProduct(Product product)
    {
        await _httpClient.PostAsJsonAsync("api/products", product);
    }
    public async Task DeleteProduct(int productId)
    {
        await _httpClient.DeleteAsync($"api/products/{productId}");
    }
    public async Task UpdateProduct(Product product)
    {
        await _httpClient.PutAsJsonAsync($"api/products/{product.Id}", product);
    }
    public async Task<Product> GetProductById(int productId)
    {
        return await _httpClient.GetFromJsonAsync<Product>($"api/products/{productId}");
    }
    public async Task UpdateProductStatus(int productId, bool status)
    {
        await _httpClient.PutAsJsonAsync($"api/products/{productId}/{status}", status);
    }
    public async Task<Product> GetProductByName(string name)
    {
        return await _httpClient.GetFromJsonAsync<Product>($"api/products/name/{name}");
    }
    public async Task UpdateProductCategory(int productId, int categoryId)
    {
        await _httpClient.GetFromJsonAsync<Product>($"api/products/{productId}/category/{categoryId}");
    }
    public async Task RemoveProductCategory(int productId, int categoryId)
    {
        await _httpClient.GetFromJsonAsync<Product>($"api/products/{productId}/category/{categoryId}");
    }

}