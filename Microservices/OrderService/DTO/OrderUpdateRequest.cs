namespace OrderService.DTO
{
    public class OrderUpdateRequest
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int? PaymentMethodId { get; set; }
        public string? PaymentName { get; set; }
        public string? ShippingMethod { get; set; }
        public string? ShippingAddress { get; set; }
        public string OrderStatus { get; set; } = "Placed";
        public List<OrderDetailRequest> Details { get; set; } = new();
    }
}
