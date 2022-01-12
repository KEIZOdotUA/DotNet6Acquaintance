using System.Linq.Expressions;

namespace Application.Interfaces.Repositories;

/// <summary>
/// Generic repository interface.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public interface IGenericRepository<T> where T : class
{
    /// <summary>
    /// Gets entity by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>
    /// Found entity.
    /// </returns>
    Task<T> GetByIdAsync(Guid id);

    /// <summary>
    /// Creates entity asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    Task CreateAsync(T entity);

    /// <summary>
    /// Updates entity asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Deletes entity asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    Task DeleteAsync(T entity);

    /// <summary>
    /// Gets entities asynchronous.
    /// </summary>
    /// <returns>
    /// All entities.
    /// </returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Gets filtered entities asynchronous.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <returns>
    /// Filtered entities.
    /// </returns>
    Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
}
