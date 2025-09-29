using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewService.Models
{
    [Table("Customer_Review")]
    public class CustomerReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Customer_Id { get; set; }

        [Required, MaxLength(200)]
        public string Customer_Name { get; set; } = string.Empty;

        [Required]
        public int Order_Id { get; set; }

        [Required]
        public DateTime Order_Date { get; set; }

        [Required]
        public int Product_Id { get; set; }

        [Required, MaxLength(200)]
        public string Product_Name { get; set; } = string.Empty;

        [Range(1, 5)]
        public byte Rating_value { get; set; }

        [MaxLength(2000)]
        public string? Comment { get; set; }

        [Required]
        public DateTime Review_Date { get; set; }

        [Required] public ReviewStatus Status { get; set; } = ReviewStatus.Pending;

    }
}
