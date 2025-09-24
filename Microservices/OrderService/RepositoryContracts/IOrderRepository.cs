using OrderService.Models;
using OrderService.RepositoryContracts;

namespace OrderService.RepositoryContracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IReadOnlyList<Order>> GetAllWithDetailsAsync();
        Task<IReadOnlyList<Order>> GetByCustomerWithDetailsAsync(int customerId);
        Task<Order?> GetByIdWithDetailsAsync(int id);
    }
}
