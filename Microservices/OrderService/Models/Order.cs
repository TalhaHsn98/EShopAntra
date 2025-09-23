using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int CustomerId { get; set; }
        [MaxLength(128)] public string CustomerName { get; set; } = string.Empty;
        public int? PaymentMethodId { get; set; }
        [MaxLength(64)] public string? PaymentName { get; set; }
        [MaxLength(64)] public string? ShippingMethod { get; set; }
        [MaxLength(256)] public string? ShippingAddress { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal BillAmount { get; set; }
        [MaxLength(32)] public string? OrderStatus { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();
    }

}
