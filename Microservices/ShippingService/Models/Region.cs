using System.ComponentModel.DataAnnotations;

namespace ShippingService.Models
{
    public class Region
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;

        public ICollection<ShipperRegion> ShipperRegions { get; set; } = new List<ShipperRegion>();
    }
}
