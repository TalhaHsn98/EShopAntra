using OrderService.Models;

namespace OrderService.RepositoryContracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer?> GetByUserIdAsync(int userId);
        Task<Customer?> GetWithAddressesByUserIdAsync(int userId);
    }
}
