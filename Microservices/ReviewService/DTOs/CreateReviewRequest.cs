using System.ComponentModel.DataAnnotations;

namespace ReviewService.DTOs
{
    public class CreateReviewRequest
    {
        [Required] public int Customer_Id { get; set; }
        [Required, MaxLength(200)] public string Customer_Name { get; set; } = string.Empty;

        [Required] public int Order_Id { get; set; }
        [Required] public DateTime Order_Date { get; set; }

        [Required] public int Product_Id { get; set; }
        [Required, MaxLength(200)] public string Product_Name { get; set; } = string.Empty;

        [Range(1, 5)] public byte Rating_value { get; set; }
        [MaxLength(2000)] public string? Comment { get; set; }

        // If client omits this, set to UtcNow in service
        public DateTime? Review_Date { get; set; }
    }
}
