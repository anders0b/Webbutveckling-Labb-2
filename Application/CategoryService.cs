using Common.Models;
using DataAccess.Interfaces;
using Services.Interfaces;

namespace Services;

public class CategoryService : ICategoryService
{
    public IUnitOfWork _unitOfWork;
    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        var categories = await _unitOfWork.Categories.GetAll();
        return categories;
    }

    public async Task<Category?> GetCategoryById(int id)
    {
        var category = await _unitOfWork.Categories.GetById(id);
        if (category != null)
        {
            return category;
        }
        return null;
    }

    public async Task CreateCategory(Category category)
    {
        await _unitOfWork.Categories.Add(category);
        _unitOfWork.Commit();
    }

    public async Task DeleteCategory(int id)
    {
        var category = await _unitOfWork.Categories.GetById(id);
        if (category != null)
        {
            await _unitOfWork.Categories.Delete(category);
            _unitOfWork.Commit();
        }
    }
}