using Core.Interfaces;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

/// <summary>
/// Generic repository interface implementation.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="Core.Interfaces.IGenericRepository&lt;T&gt;" />
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<T> _dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
    /// </summary>
    /// <param name="appDbContext">The application database context.</param>
    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _dbSet = appDbContext.Set<T>();
    }

    /// <summary>
    /// Gets entity by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<T> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);

        return entity;
    }

    /// <summary>
    /// Creates entity asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public async Task CreateAsync(T entity)
    {
        _dbSet.Add(entity);

        await _appDbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Updates entity asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        _appDbContext.Entry(entity).State = EntityState.Modified;

        await _appDbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes entity asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public async Task DeleteAsync(T entity)
    {
        if (_appDbContext.Entry(entity).State == EntityState.Detached)
            _dbSet.Attach(entity);

        _dbSet.Remove(entity);

        await _appDbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes entity by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public async Task DeleteByIdAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);

        await DeleteAsync(entity);
    }

    /// <summary>
    /// Gets entities asynchronous.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    /// Gets filtered entities asynchronous.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <returns></returns>
    public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
}
