namespace OrderService.DTO
{

    public class OrderResponse
    {
        public int Id { get; set; }
        public string OrderDate { get; set; } = "";
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int? PaymentMethodId { get; set; }
        public string? PaymentName { get; set; }
        public string? ShippingMethod { get; set; }
        public string? ShippingAddress { get; set; }
        public decimal BillAmount { get; set; }
        public string? OrderStatus { get; set; }
        public List<OrderDetailResponse> Details { get; set; } = new();
    }
}
