using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class PersonalContract
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(150)]
        public string BriefName { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public int TotalDeliveryTime { get; set; } = 0;
        public DateTime DeliveryDate { get; set; } = DateTime.UtcNow;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public string? Note { get; set; }
        [MaxLength(30)]
        public string Status { get; set; } = "Draft";   //Applied

        //======================[ Foreign Key ]======================
        public virtual Proposal Proposal { get; set; } = null!;
        public virtual Account Employer { get; set; } = null!;
        public virtual Account Freelancer { get; set; } = null!;
        public virtual Transaction? Transaction { get; set; }
    }
}
