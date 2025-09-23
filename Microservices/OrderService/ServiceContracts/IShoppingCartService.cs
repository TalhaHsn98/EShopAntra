using OrderService.DTO;
using OrderService.Models;

namespace OrderService.ServiceContracts
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart?> GetByCustomerIdAsync(int customerId);
        Task<int> SaveAsync(ShoppingCart cart);
        Task<int> SaveAsync(ShoppingCartCreateRequest dto);

        Task<bool> DeleteAsync(int cartId);
        Task<bool> DeleteItemAsync(int itemId);
    }

}
