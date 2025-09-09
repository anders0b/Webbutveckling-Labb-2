using Common.Models;
using DataAccess.Interfaces;
using Services.Interfaces;

namespace Services;

public class CategoryService(IUnitOfWork unitOfWork) : ICategoryService
{
    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        var categories = await unitOfWork.Categories.GetAll();
        return categories;
    }

    public async Task<Category?> GetCategoryById(int id)
    {
        var category = await unitOfWork.Categories.GetById(id);
        return category;
    }

    public async Task CreateCategory(Category category)
    {
        await unitOfWork.Categories.Add(category);
        unitOfWork.Commit();
    }

    public async Task DeleteCategory(int id)
    {
        var category = await unitOfWork.Categories.GetById(id);
        if (category != null)
        {
            await unitOfWork.Categories.Delete(category);
            unitOfWork.Commit();
        }
    }
}