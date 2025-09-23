using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public ShoppingCart Cart { get; set; } = null!;
        public int ProductId { get; set; }
        [MaxLength(128)] public string ProductName { get; set; } = string.Empty;
        public int Qty { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal Price { get; set; }
    }

}
