using AutoMapper;
using OrderService.DTO;
using OrderService.Models;
using OrderService.Repositories;
using OrderService.RepositoryContracts;
using OrderService.ServiceContracts;

namespace OrderService.Services
{
    public class OrdersService : IOrderService
    {
        private readonly IOrderRepository _orders;
        private readonly IRepository<OrderDetail> _details;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrdersService(IOrderRepository orders, IRepository<OrderDetail> details, IUnitOfWork uow, IMapper mapper)
        {
            _orders = orders; _details = details; _uow = uow; _mapper = mapper;
        }

        public async Task<List<Order>> GetAllAsync()
            => (await _orders.GetAllWithDetailsAsync()).ToList();

        public async Task<List<Order>> GetByCustomerAsync(int customerId)
            => (await _orders.GetByCustomerWithDetailsAsync(customerId)).ToList();

        public Task<Order?> GetByIdAsync(int id)
            => _orders.GetByIdWithDetailsAsync(id);

        public async Task<int> CreateAsync(OrderCreateRequest dto)
        {
            var order = _mapper.Map<Order>(dto);
            order.OrderDate = System.DateTime.UtcNow;
            order.OrderStatus = "Placed";
            order.BillAmount = ComputeBill(order);
            await _orders.AddAsync(order);
            await _uow.SaveChangesAsync();
            return order.Id;
        }

        public async Task<bool> UpdateAsync(OrderUpdateRequest dto)
        {
            var existing = await _orders.GetByIdWithDetailsAsync(dto.Id);
            if (existing is null) return false;
            existing.CustomerId = dto.CustomerId;
            existing.CustomerName = dto.CustomerName;
            existing.PaymentMethodId = dto.PaymentMethodId;
            existing.PaymentName = dto.PaymentName;
            existing.ShippingMethod = dto.ShippingMethod;
            existing.ShippingAddress = dto.ShippingAddress;
            existing.OrderStatus = dto.OrderStatus;
            if (existing.Details.Any()) await _details.DeleteRangeAsync(existing.Details);
            existing.Details = dto.Details.Select(d => new OrderDetail
            {
                ProductId = d.ProductId,
                ProductName = d.ProductName,
                Qty = d.Qty,
                Price = d.Price,
                Discount = d.Discount
            }).ToList();
            existing.BillAmount = ComputeBill(existing);
            await _orders.UpdateAsync(existing);
            await _uow.SaveChangesAsync();
            return true;
        }

        public async Task<string?> CheckStatusAsync(int orderId)
        {
            var order = await _orders.GetByIdAsync(orderId);
            return order?.OrderStatus;
        }

        public async Task<bool> MarkCompletedAsync(int orderId)
        {
            var order = await _orders.GetByIdAsync(orderId);
            if (order is null) return false;
            order.OrderStatus = "Completed";
            await _orders.UpdateAsync(order);
            await _uow.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CancelAsync(int orderId)
        {
            var order = await _orders.GetByIdAsync(orderId);
            if (order is null) return false;
            order.OrderStatus = "Cancelled";
            await _orders.UpdateAsync(order);
            await _uow.SaveChangesAsync();
            return true;
        }

        private decimal ComputeBill(Order order)
            => order.Details?.Sum(d => (d.Price - d.Discount) * d.Qty) ?? 0m;
    }
}
