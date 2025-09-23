using Microsoft.EntityFrameworkCore;
using OrderService.RepositoryContracts;
using OrderService.Data;
using OrderService.Models;

namespace OrderService.Repositories
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(OrdersDbContext db) : base(db) { }

        public async Task<ShoppingCart?> GetByCustomerIdAsync(int customerId)
        {
            return await _db.ShoppingCarts.Include(c => c.Items).AsNoTracking()
               .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
    }
}
