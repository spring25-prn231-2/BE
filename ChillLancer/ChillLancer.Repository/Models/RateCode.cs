using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class RateCode
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(50)]
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        [Required, MaxLength(30)]
        public string Type { get; set; } = "Promotion";//Operating Fee
        public double Percentage { get; set; } = 0;// 99.99d = 99.99  %
        [MaxLength(30)]
        public string Status { get; set; } = "Active";

        //======================[ Foreign Key ]======================
        public virtual ICollection<Transaction>? SystemFeeTransactions { get; set; }
        public virtual ICollection<Transaction>? PromotionTransactions { get; set; }
    }
}
