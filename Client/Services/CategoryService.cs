using Common.Models;

namespace FrontEnd.Services;

public class CategoryService
{
    private readonly HttpClient _httpClient;
    public CategoryService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }
    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("api/categories");
    }
    public async Task<Category> GetCategoryById(int id)
    {
        return await _httpClient.GetFromJsonAsync<Category>($"api/categories/{id}");
    }
    public async Task CreateCategory(Category category)
    {
        await _httpClient.PostAsJsonAsync("api/categories", category);
    }
    public async Task DeleteCategory(int id)
    {
        await _httpClient.DeleteAsync($"api/categories/{id}");
    }
}