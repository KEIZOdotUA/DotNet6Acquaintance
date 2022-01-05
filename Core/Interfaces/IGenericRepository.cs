using System.Linq.Expressions;

namespace Core.Interfaces;

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
    /// <returns></returns>
    Task<T> GetByIdAsync(Guid id);

    /// <summary>
    /// Creates entity asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    Task CreateAsync(T entity);

    /// <summary>
    /// Updates entity asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Deletes entity asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    Task DeleteAsync(T entity);

    /// <summary>
    /// Deletes entity by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task DeleteByIdAsync(Guid id);

    /// <summary>
    /// Gets entities asynchronous.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Gets filtered entities asynchronous.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <returns></returns>
    Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
}
