using System.Linq.Expressions;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly BaseContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(BaseContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public void Add(TEntity obj)
    {
        _dbSet.Add(obj);
    }

    public void Update(TEntity obj)
    {
        _dbSet.Update(obj);
    }

    public void Remove(Guid id)
    {
        _dbSet.Remove(_dbSet.Find(id));
    }

    public void Remove(TEntity obj)
    {
        _dbSet.Remove(obj);
    }

    public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression, params string[] includes)
    {
        return _dbSet.Where(expression).Includes(includes);
    }

    public IQueryable<TEntity> GetAll(params string[] includes)
    {
        return _dbSet.Includes(includes);
    }

    public ValueTask<TEntity> GetByIdAsync(Guid id)
    {
        return _dbSet.FindAsync(id);
    }

    public Task<List<TEntity>> GetAllAsync(params string[] includes)
    {
        return _dbSet.Includes(includes).ToListAsync();
    }

    public void AddRange(IEnumerable<TEntity> items)
    {
        _dbSet.AddRange(items);
    }

    public void RemoveRange(IEnumerable<TEntity> items)
    {
        _dbSet.RemoveRange(items);
    }

    public bool Any(Expression<Func<TEntity, bool>> where)
    {
        return _dbSet.Any(where);
    }

    public int Count()
    {
        return _dbSet.Count();
    }

    public TEntity GetElementByExpression(Expression<Func<TEntity, bool>> expression, params string[] includes)
    {
        return _dbSet.Where(expression).Includes(includes).FirstOrDefault();
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }

    public void UpdateRange(IEnumerable<TEntity> items)
    {
        _dbSet.UpdateRange(items);
    }
}