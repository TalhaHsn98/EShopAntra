using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShippingService.DTOs
{
    public class ShipperRequestModel
    {
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(256)]
        public string Name { get; set; } = null!;

        [EmailAddress, MaxLength(255)]
        public string? Email { get; set; }

        [RegularExpression(@"^\d{10}$")]
        public string? Phone { get; set; }

        [Required, MinLength(2), MaxLength(256)]
        public string ContactPerson { get; set; } = null!;
    }
}
