using Microsoft.EntityFrameworkCore;
using OrderService.RepositoryContracts;
using OrderService.Data;
using System.Linq.Expressions;

namespace OrderService.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly OrdersDbContext _db;
        protected readonly DbSet<T> _set;

        public BaseRepository(OrdersDbContext db) { _db = db; _set = db.Set<T>(); }

        public virtual async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);

        public virtual async Task<IReadOnlyList<T>> ListAsync() => await _set.AsNoTracking().ToListAsync();

        public virtual async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> predicate)
            => await _set.AsNoTracking().Where(predicate).ToListAsync();

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
            => predicate is null ? await _set.CountAsync() : await _set.CountAsync(predicate);

        public virtual async Task<T> AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            return entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities) => await _set.AddRangeAsync(entities);

        public virtual Task UpdateAsync(T entity)
        {
            _set.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync(T entity)
        {
            _set.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _set.RemoveRange(entities);
            return Task.CompletedTask;
        }
    }
}
