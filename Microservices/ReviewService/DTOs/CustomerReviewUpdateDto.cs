using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ReviewService.DTOs
{
    public class CustomerReviewUpdateDto
    {
        [Required] public int id { get; set; }
        [Range(1, 5)] public byte? ratingValue { get; set; }
        [MaxLength(2000)] public string? comment { get; set; }
        public DateTime? reviewDate { get; set; }
    }
}
