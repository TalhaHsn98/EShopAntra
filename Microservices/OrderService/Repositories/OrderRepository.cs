using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;
using OrderService.RepositoryContracts;

namespace OrderService.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrdersDbContext db) : base(db) { }

        public async Task<IReadOnlyList<Order>> GetAllWithDetailsAsync()
            => await _db.Orders.AsNoTracking().Include(o => o.Details).ToListAsync();

        public async Task<IReadOnlyList<Order>> GetByCustomerWithDetailsAsync(int customerId)
            => await _db.Orders.AsNoTracking()
               .Where(o => o.CustomerId == customerId)
               .Include(o => o.Details)
               .ToListAsync();

        public async Task<Order?> GetByIdWithDetailsAsync(int id)
            => await _db.Orders.Include(o => o.Details).FirstOrDefaultAsync(o => o.Id == id);
    }
}
