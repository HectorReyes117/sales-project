using System.Linq.Expressions;

namespace Sales.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity: class
{
    Task Save(TEntity entity);
    Task Save(List<TEntity> entities);
    Task Update(TEntity entity);
    Task Update(List<TEntity> entities);
    Task<TEntity?> Get(int id);
    Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter);
    Task<bool> Exist(Expression<Func<TEntity, bool>> filter);
}