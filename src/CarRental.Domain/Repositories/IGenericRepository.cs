using System.Linq.Expressions;
using CarRental.Domain.Primitives;

namespace CarRental.Domain.Repositories;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    TEntity GetOne(Guid id);
    Task<TEntity> GetOneAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[]? includes);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void AddAsync(TEntity entity);
    void AddRangeAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    Task SaveChangesAsync();
}