using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ReviewService.DTOs
{
    public class CustomerReviewCreateDto
    {
        [Required] public int customerId { get; set; }
        [Required, MaxLength(200)] public string customerName { get; set; } = string.Empty;
        [Required] public int orderId { get; set; }
        [Required] public DateTime orderDate { get; set; }
        [Required] public int productId { get; set; }
        [Required, MaxLength(200)] public string productName { get; set; } = string.Empty;
        [Range(1, 5)] public byte ratingValue { get; set; }
        [MaxLength(2000)] public string? comment { get; set; }
        public DateTime? reviewDate { get; set; }
    }
}
