using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(20)]
        public string Code { get; set; } = null!;

        [Required, MaxLength(255)]
        public string BriefDescribe { get; set; } = null!;

        [Required, MaxLength(30)]
        public string Type { get; set; } = null!;//ProjectContract | PersonalContract
        public DateTime HandleDate { get; set; } = DateTime.UtcNow;
        public decimal FeePrice { get; set; } = 0;
        public decimal TotalPrice { get; set; } = 0;

        [MaxLength(30)]
        public string PayMethod { get; set; } = "Transfer";
        [MaxLength(30)]
        public string Status { get; set; } = "Complete";

        //======================[ Foreign Key ]======================
        public virtual Account Customer { get; set; } = null!;
        public virtual RateCode SystemFee { get; set; } = null!;
        public virtual RateCode? Promotion { get; set; }
        public virtual ProjectContract? ProjectContract { get; set; }
        public virtual PersonalContract? PersonalContract { get; set; }
    }
}
