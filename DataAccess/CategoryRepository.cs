using Common.Models;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly BrodDbContext _dbContext;
    public CategoryRepository(BrodDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}