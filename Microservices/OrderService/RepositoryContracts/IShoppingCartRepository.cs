using OrderService.Models;

namespace OrderService.RepositoryContracts

{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        Task<ShoppingCart?> GetByCustomerIdAsync(int customerId);
    }
}
