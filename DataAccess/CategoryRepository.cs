using Common.Models;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly AndersBrodContext _context;
    public CategoryRepository(AndersBrodContext context) : base(context)
    {
        _context = context;
    }
}