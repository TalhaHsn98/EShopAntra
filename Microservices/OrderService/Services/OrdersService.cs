using AutoMapper;
using OrderService.DTO;
using OrderService.Events;
using OrderService.Messaging;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderEventPublisher _orderEventPublisher;

        public OrdersService(
            IOrderRepository orders,
            IRepository<OrderDetail> details,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOrderEventPublisher orderEventPublisher)
        {
            _orders = orders;
            _details = details;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderEventPublisher = orderEventPublisher;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var list = await _orders.GetAllWithDetailsAsync();
            return list.ToList();
        }

        public async Task<List<Order>> GetByCustomerAsync(int customerId)
        {
            var list = await _orders.GetByCustomerWithDetailsAsync(customerId);
            return list.ToList();
        }

        public Task<Order?> GetByIdAsync(int id)
        {
            return _orders.GetByIdWithDetailsAsync(id);
        }

        public async Task<int> CreateAsync(OrderCreateRequest dto)
        {
            var order = _mapper.Map<Order>(dto);
            order.OrderDate = System.DateTime.UtcNow;
            order.OrderStatus = "Placed";
            order.BillAmount = ComputeBill(order);
            await _orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
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
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<string?> CheckStatusAsync(int orderId)
        {
            var order = await _orders.GetByIdAsync(orderId);
            return order?.OrderStatus;
        }

        public async Task<bool> MarkCompletedAsync(int orderId)
        {
            var order = await _orders.GetByIdWithDetailsAsync(orderId);
            if (order is null) return false;

            order.OrderStatus = "Completed";
            await _orders.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();

            var evt = new OrderCompletedEvent
            {
                OrderId = order.Id,
                OrderDateUtc = order.OrderDate,
                CustomerId = order.CustomerId,
                CustomerName = order.CustomerName,
                ShippingMethod = order.ShippingMethod,
                ShippingAddress = order.ShippingAddress,
                PaymentMethodId = order.PaymentMethodId,
                PaymentName = order.PaymentName,
                BillAmount = order.BillAmount,
                Items = order.Details.Select(d => new OrderCompletedEventItem
                {
                    ProductId = d.ProductId,
                    ProductName = d.ProductName,
                    Qty = d.Qty,
                    Price = d.Price,
                    Discount = d.Discount
                }).ToList()
            };

            await _orderEventPublisher.PublishOrderCompletedAsync(evt);
            return true;
        }

        public async Task<bool> CancelAsync(int orderId)
        {
            var order = await _orders.GetByIdAsync(orderId);
            if (order is null) return false;
            order.OrderStatus = "Cancelled";
            await _orders.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        private decimal ComputeBill(Order order)
        {
            return order.Details?.Sum(d => (d.Price - d.Discount) * d.Qty) ?? 0m;
        }
    }
}
