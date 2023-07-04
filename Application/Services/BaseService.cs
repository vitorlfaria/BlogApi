using System.Linq.Expressions;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class BaseService<T, TDto, TR> : IBaseService<TDto>
    where T : class
    where TDto : class
    where TR : IBaseRepository<T>
{
    private readonly IMapper _mapper;
    private readonly TR _repository;

    public BaseService(TR repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public void Add(TDto obj)
    {
        _repository.Add(_mapper.Map<T>(obj));
        _repository.SaveChanges();
    }

    public void Update(TDto obj)
    {
        _repository.Update(_mapper.Map<T>(obj));
        _repository.SaveChanges();
    }

    public void Remove(Guid id)
    {
        _repository.Remove(id);
        _repository.SaveChanges();
    }

    public List<TDto> GetAll(params string[] includes)
    {
        var list = _repository.GetAll(includes).ToList();
        return _mapper.Map<List<TDto>>(list);
    }

    public int Count()
    {
        return _repository.Count();
    }

    public void AddRange(List<TDto> obj)
    {
        _repository.AddRange(_mapper.Map<List<T>>(obj));
    }

    public void RemoveRange(List<TDto> objs)
    {
        _repository.RemoveRange(_mapper.Map<List<T>>(objs));
    }

    public void UpdateRange(IEnumerable<TDto> objs)
    {
        _repository.UpdateRange(_mapper.Map<IEnumerable<T>>(objs));
    }

    public IQueryable<TDto> GetByExpression(Expression<Func<TDto, bool>> expression, params string[] includes)
    {
        var result = _repository.GetByExpression(_mapper.Map<Expression<Func<T, bool>>>(expression), includes);
        return _mapper.Map<IQueryable<TDto>>(result);
    }

    public TDto GetElementByExpression(Expression<Func<TDto, bool>> expression, params string[] includes)
    {
        var result = _repository.GetElementByExpression(_mapper.Map<Expression<Func<T, bool>>>(expression), includes);
        return _mapper.Map<TDto>(result);
    }
}