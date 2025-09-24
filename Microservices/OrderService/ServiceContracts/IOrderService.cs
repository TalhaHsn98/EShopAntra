using OrderService.DTO;
using OrderService.Models;

namespace OrderService.ServiceContracts
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();
        Task<List<Order>> GetByCustomerAsync(int customerId);
        Task<Order?> GetByIdAsync(int id);
        Task<int> CreateAsync(OrderCreateRequest dto);
        Task<bool> UpdateAsync(OrderUpdateRequest dto);
        Task<string?> CheckStatusAsync(int orderId);
        Task<bool> MarkCompletedAsync(int orderId);
        Task<bool> CancelAsync(int orderId);
    }
}
