using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IBaseService<TDto> : IDisposable where TDto : class
{
    void Add(TDto obj);

    void Update(TDto obj);

    void Remove(Guid id);

    List<TDto> GetAll(params string[] includes);

    int Count();

    void AddRange(List<TDto> obj);

    void RemoveRange(List<TDto> objs);

    void UpdateRange(IEnumerable<TDto> objs);
    
    IQueryable<TDto> GetByExpression(Expression<Func<TDto, bool>> expression, params string[] includes);

    TDto GetElementByExpression(Expression<Func<TDto, bool>> expression, params string[] includes);
}