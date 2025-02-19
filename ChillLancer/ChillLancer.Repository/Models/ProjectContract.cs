using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class ProjectContract
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(150)]
        public string BriefName { get; set; } = null!;
        public decimal TotalPay { get; set; } = 0;
        public decimal Paid { get; set; } = 0;
        public DateTime? AppliedDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? Note { get; set; }
        [MaxLength(30)]
        public string Status { get; set; } = "Draft";   //Applied

        //======================[ Foreign Key ]======================
        public virtual Project? Project { get; set; }
        public virtual Account Freelancer { get; set; } = null!;
        public virtual Transaction? Transaction { get; set; }
        public virtual ICollection<Process>? Processes { get; set; }
    }
}
