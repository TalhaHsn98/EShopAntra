using System.ComponentModel.DataAnnotations;

namespace OrderService.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        [MaxLength(64)] public string Name { get; set; } = string.Empty;
        public ICollection<PaymentMethod> Methods { get; set; } = new List<PaymentMethod>();
    }
}
