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
        public bool IsActive = false;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime HandleDate { get; set; } = DateTime.UtcNow;
        public decimal FeePrice { get; set; } = 0;
        public decimal TotalPrice { get; set; } = 0;
        public string? Note { get; set; }

        [MaxLength(30)]
        public string PayMethod { get; set; } = "Transfer";
        [MaxLength(30)]
        public string Status { get; set; } = "Complete";

        //======================[ Foreign Key ]======================
        public virtual Account? Freelancer { get; set; }
        public virtual Account? Employer { get; set; }
        public virtual RateCode SystemFee { get; set; } = null!;
        public virtual RateCode? Promotion { get; set; }
        public virtual Package? Package { get; set; }
        public virtual ICollection<Proposal>? Proposals { get; set; }

        //public virtual ICollection<ProjectContract>? ProjectContracts { get; set; }
        //public virtual PersonalContract? PersonalContract { get; set; }
    }
}
