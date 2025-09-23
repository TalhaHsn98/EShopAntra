using System.ComponentModel.DataAnnotations;

namespace ShippingService.Models
{
    public class ShippingDetail
    {
        public int Id { get; set; }

        [Required]
        public int Order_Id { get; set; }

        [Required]
        public int Shipper_Id { get; set; }

        [Required]
        public ShippingStatus Shipping_Status { get; set; } = ShippingStatus.Pending;

        [MaxLength(100)]
        public string? Tracking_Number { get; set; }

        public Shipper? Shipper { get; set; }
    }
}
