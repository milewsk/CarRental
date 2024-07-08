using System.Linq.Expressions;
using CarRental.Domain.Primitives;

namespace CarRental.Domain.Repositories;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    TEntity GetOne(Guid id);
    Task<TEntity> GetOneAsync(Guid id);
    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[]? includes);
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    Task SaveChangesAsync();
}