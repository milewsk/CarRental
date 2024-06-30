using System.Linq.Expressions;
using CarRental.Domain.Primitives;

namespace CarRental.Domain.Repositories;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetOneAsync(Guid id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    Task<bool> AddAsync(TEntity entity);

    void AddRange(IEnumerable<TEntity> entities);

    Task<bool> RemoveAsync(TEntity entity);

    void RemoveRange(IEnumerable<TEntity> entities);

    Task SaveChangesAsync();
}