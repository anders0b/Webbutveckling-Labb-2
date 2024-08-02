using Common.Models;

namespace FrontEnd.Services;

public class CategoryService
{
    private readonly HttpClient _httpClient;
    public CategoryService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }
    public async Task<IEnumerable<CategoryModel>> GetAllCategories()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<CategoryModel>>("api/categories");
    }
    public async Task<CategoryModel> GetCategoryById(int id)
    {
        return await _httpClient.GetFromJsonAsync<CategoryModel>($"api/categories/{id}");
    }
    public async Task CreateCategory(CategoryModel category)
    {
        await _httpClient.PostAsJsonAsync("api/categories", category);
    }
    public async Task DeleteCategory(int id)
    {
        await _httpClient.DeleteAsync($"api/categories/{id}");
    }
}