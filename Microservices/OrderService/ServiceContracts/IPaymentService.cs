using OrderService.DTO;

namespace OrderService.ServiceContracts
{
    public interface IPaymentService
    {
        Task<List<PaymentTypeResponse>> ListTypesAsync();
        Task<int> CreateTypeAsync(PaymentTypeRequest dto);
        Task<List<PaymentMethodResponse>> GetMethodsByCustomerAsync(int customerId);
        Task<int> SaveMethodAsync(PaymentMethodRequest dto);
        Task<bool> DeleteMethodAsync(int id);
        Task<bool> SetDefaultAsync(int id);
    }
}
