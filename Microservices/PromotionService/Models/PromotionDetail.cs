using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionService.Models
{

    [Table("PromotionDetails")]
    public class PromotionDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Promotion))]
        public int PromotionId { get; set; }

        public int ProductCategoryId { get; set; }

        [Required, MaxLength(128)]
        public string ProductCategoryName { get; set; } = string.Empty;

        public Promotion? Promotion { get; set; }
    }
}
