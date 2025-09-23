using System.ComponentModel.DataAnnotations;

namespace OrderService.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; } = null!;
        [MaxLength(64)] public string Provider { get; set; } = string.Empty;
        [MaxLength(64)] public string AccountNumber { get; set; } = string.Empty;
        public DateTime? Expiry { get; set; }
        public bool IsDefault { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
