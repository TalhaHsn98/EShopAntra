using Microsoft.AspNetCore.Mvc;

namespace ReviewService.DTOs
{
    public class CustomerReviewResponseDto
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public string customerName { get; set; } = string.Empty;
        public int orderId { get; set; }
        public DateTime orderDate { get; set; }
        public int productId { get; set; }
        public string productName { get; set; } = string.Empty;
        public byte ratingValue { get; set; }
        public string? comment { get; set; }
        public DateTime reviewDate { get; set; }
        public string status { get; set; } = "Pending";
    }
}
