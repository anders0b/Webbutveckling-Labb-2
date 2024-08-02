using DataAccess.Entities;

namespace Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category?> GetCategoryById(int id);
    Task CreateCategory(Category category);
    Task DeleteCategory(int id);
}