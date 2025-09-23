using OrderService.RepositoryContracts;
using OrderService.Data;

namespace OrderService.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrdersDbContext _db;
        public UnitOfWork(OrdersDbContext db) => _db = db;
        public Task<int> SaveChangesAsync() => _db.SaveChangesAsync();

       
    }
}
