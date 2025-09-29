using Microsoft.AspNetCore.Mvc;

namespace ShippingService.DTOs
{
    public class ShipperResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? ContactPerson { get; set; }
    }
}
