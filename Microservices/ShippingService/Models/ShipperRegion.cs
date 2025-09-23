using System.ComponentModel.DataAnnotations;

namespace ShippingService.Models
{
    public class ShipperRegion
    {
        [Required]
        public int RegionId { get; set; }

        [Required]
        public int ShipperId { get; set; }

        public bool Active { get; set; } = true;

        public Region? Region { get; set; }
        public Shipper? Shipper { get; set; }
    }
}
