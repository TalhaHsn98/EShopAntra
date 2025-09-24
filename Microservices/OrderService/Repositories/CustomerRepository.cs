using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;
using OrderService.RepositoryContracts;

namespace OrderService.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OrdersDbContext db) : base(db) { }

        public async Task<Customer?> GetByUserIdAsync(int userId)
        {
            var entity = await _db.Customers.FirstOrDefaultAsync(c => c.UserId == userId);
            return entity;
        }

        public async Task<Customer?> GetWithAddressesByUserIdAsync(int userId)
        {
            var entity = await _db.Customers
                .Include(c => c.UserAddresses)
                    .ThenInclude(ua => ua.Address)
                .FirstOrDefaultAsync(c => c.UserId == userId);
            return entity;
        }
    }
}
