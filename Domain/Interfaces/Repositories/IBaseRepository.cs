using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    void Add(TEntity obj);

    void Update(TEntity obj);

    void Remove(Guid id);

    void Remove(TEntity obj);

    IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression, params string[] includes);

    IQueryable<TEntity> GetAll(params string[] includes);

    ValueTask<TEntity> GetByIdAsync(Guid id);

    Task<List<TEntity>> GetAllAsync(params string[] includes);

    void AddRange(IEnumerable<TEntity> itens);

    void RemoveRange(IEnumerable<TEntity> itens);

    bool Any(Expression<Func<TEntity, bool>> where);

    int Count();

    TEntity GetElementByExpression(Expression<Func<TEntity, bool>> expression, params string[] includes);

    bool SaveChanges();

    void UpdateRange(IEnumerable<TEntity> items);
}