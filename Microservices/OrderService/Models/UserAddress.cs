namespace OrderService.Models
{
    public class UserAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public bool IsDefaultAddress { get; set; }
        public Customer Customer { get; set; } = null!;
        public Address Address { get; set; } = null!;
    }
}
