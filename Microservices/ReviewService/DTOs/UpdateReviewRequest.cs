using System.ComponentModel.DataAnnotations;

namespace ReviewService.DTOs
{
    public class UpdateReviewRequest
    {
        [Range(1, 5)] public byte? Rating_value { get; set; }
        [MaxLength(2000)] public string? Comment { get; set; }
        public DateTime? Review_Date { get; set; }
    }
}
