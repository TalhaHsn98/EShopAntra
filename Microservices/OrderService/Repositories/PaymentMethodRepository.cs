using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;
using OrderService.RepositoryContracts;

namespace OrderService.Repositories
{
    public class PaymentMethodRepository : BaseRepository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(OrdersDbContext db) : base(db) { }

        public async Task<IReadOnlyList<PaymentMethod>> GetByCustomerAsync(int customerId)
            => await _db.PaymentMethods.AsNoTracking()
               .Include(p => p.PaymentType)
               .Where(p => p.CustomerId == customerId)
               .ToListAsync();

        public async Task<PaymentMethod?> GetDefaultForCustomerAsync(int customerId)
            => await _db.PaymentMethods
               .Include(p => p.PaymentType)
               .FirstOrDefaultAsync(p => p.CustomerId == customerId && p.IsDefault);
    }
}
