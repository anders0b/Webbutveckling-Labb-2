using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AndersBrodContext _context;

    public Repository(AndersBrodContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }
    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}