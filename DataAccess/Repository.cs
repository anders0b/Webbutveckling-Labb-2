using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly BrodDbContext _dbContext;

    public Repository(BrodDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
    public async Task<T?> GetById(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }
    public async Task Add(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }
    public async Task Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }
    public async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }
}