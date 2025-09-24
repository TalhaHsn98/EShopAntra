namespace OrderService.DTO
{
    public class OrderCreateRequest
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int? PaymentMethodId { get; set; }
        public string? PaymentName { get; set; }
        public string? ShippingMethod { get; set; }
        public string? ShippingAddress { get; set; }
        public List<OrderDetailRequest> Details { get; set; } = new();
    }
}
