using System.Linq.Expressions;
using CarRental.Domain.Primitives;
using CarRental.Domain.Repositories;
using CarRental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CarRental.Infrastructure.Repositories;

public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
{
    private readonly ApplicationDbContext _context;

    protected GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public virtual TEntity GetOne(Guid id)
    {
        return _context.Set<TEntity>().FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
    }

    public virtual async Task<TEntity> GetOneAsync(Guid id)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id) ??
               throw new InvalidOperationException();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[]? includes)
    {
        IQueryable<TEntity> list = _context.Set<TEntity>();

        if (includes == null) return await list.ToListAsync();

        foreach (var include in includes)
        {
            list.Include(include);
        }

        return await list.ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public virtual void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public virtual async void AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public virtual async void AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public virtual void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }

    public virtual Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}