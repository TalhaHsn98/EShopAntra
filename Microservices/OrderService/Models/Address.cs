using System.ComponentModel.DataAnnotations;

namespace OrderService.Models
{
    public class Address
    {
        public int Id { get; set; }
        [MaxLength(128)] public string? Street1 { get; set; }
        [MaxLength(128)] public string? Street2 { get; set; }
        [MaxLength(64)] public string? City { get; set; }
        [MaxLength(64)] public string? State { get; set; }
        [MaxLength(16)] public string? Zipcode { get; set; }
        [MaxLength(64)] public string? Country { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
    }
}
