using OrderService.DTO;

namespace OrderService.ServiceContracts
{
    public interface ICustomerService
    {
        Task<List<CustomerAddressResponse>> GetCustomerAddressByUserIdAsync(int userId);
        Task<int> SaveCustomerAddressAsync(CustomerAddressSaveRequest request);
    }
}
