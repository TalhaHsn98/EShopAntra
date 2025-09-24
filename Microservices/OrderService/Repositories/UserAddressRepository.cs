using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;
using OrderService.RepositoryContracts;

namespace OrderService.Repositories
{
    public class UserAddressRepository : BaseRepository<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(OrdersDbContext db) : base(db) { }

        public async Task<List<UserAddress>> GetByCustomerIdAsync(int customerId)
        {
            var list = await _db.UserAddresses
                .Include(ua => ua.Address)
                .Where(ua => ua.CustomerId == customerId)
                .ToListAsync();
            return list;
        }

        public async Task<UserAddress?> GetDefaultByCustomerIdAsync(int customerId)
        {
            var entity = await _db.UserAddresses
                .Include(ua => ua.Address)
                .FirstOrDefaultAsync(ua => ua.CustomerId == customerId && ua.IsDefaultAddress);
            return entity;
        }
    }
}
