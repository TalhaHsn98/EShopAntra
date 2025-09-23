using System.ComponentModel.DataAnnotations;

namespace OrderService.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [MaxLength(128)] public string CustomerName { get; set; } = string.Empty;
        public Customer Customer { get; set; } = null!;
        public ICollection<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    }
}
