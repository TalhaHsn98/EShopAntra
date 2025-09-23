using System.ComponentModel.DataAnnotations;

namespace OrderService.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(64)] 
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(64)] 
        public string LastName { get; set; } = string.Empty;

        [MaxLength(16)] 
        public string? Gender { get; set; }
        [MaxLength(20)] 
        public string? Phone { get; set; }
        [MaxLength(256)] 
        public string? Profile_PIC { get; set; }
        public int? UserId { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
        public ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
        public ICollection<ShoppingCart> Carts { get; set; } = new List<ShoppingCart>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
