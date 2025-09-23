using System.Linq.Expressions;

namespace OrderService.RepositoryContracts
{
    public interface IRepository<T> where T: class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAsync();
        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>>? predicate = null);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
