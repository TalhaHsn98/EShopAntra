using OrderService.Models;
using System;

namespace OrderService.RepositoryContracts
{
    public interface IPaymentMethodRepository : IRepository<PaymentMethod>
    {
        Task<IReadOnlyList<PaymentMethod>> GetByCustomerAsync(int customerId);
        Task<PaymentMethod?> GetDefaultForCustomerAsync(int customerId);
    }

}
