using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionService.Models
{

    [Table("Promotions")]
    public class Promotion
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1024)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Discount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ICollection<PromotionDetail> PromotionDetails { get; set; } = new List<PromotionDetail>();
    }
}
