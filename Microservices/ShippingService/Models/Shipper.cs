using System.ComponentModel.DataAnnotations;

namespace ShippingService.Models
{
    public class Shipper
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = null!;

        [EmailAddress, MaxLength(200)]
        public string? EmailId { get; set; }

        [MaxLength(30)]
        public string? Phone { get; set; }

        [MaxLength(150)]
        public string? Contact_Person { get; set; }

        public ICollection<ShipperRegion> ShipperRegions { get; set; } = new List<ShipperRegion>();
        public ICollection<ShippingDetail> ShippingDetails { get; set; } = new List<ShippingDetail>();
    }
}
