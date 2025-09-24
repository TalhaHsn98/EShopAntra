namespace OrderService.DTO
{
    public class PaymentMethodRequest
    {
        public int? Id { get; set; }
        public int PaymentTypeId { get; set; }
        public string Provider { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public System.DateTime? Expiry { get; set; }
        public bool IsDefault { get; set; }
        public int CustomerId { get; set; }
    }
}
