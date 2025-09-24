using OrderService.Models;

namespace OrderService.RepositoryContracts
{
    public interface IUserAddressRepository : IRepository<UserAddress>
    {
        Task<List<UserAddress>> GetByCustomerIdAsync(int customerId);
        Task<UserAddress?> GetDefaultByCustomerIdAsync(int customerId);
    }
}
