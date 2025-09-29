namespace OrderService.Events
{
    public class OrderCompletedEvent
    {
        public int OrderId { get; set; }
        public DateTime OrderDateUtc { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string? ShippingMethod { get; set; }
        public string? ShippingAddress { get; set; }
        public int? PaymentMethodId { get; set; }
        public string? PaymentName { get; set; }
        public decimal BillAmount { get; set; }
        public List<OrderCompletedEventItem> Items { get; set; } = new();
    }
}
