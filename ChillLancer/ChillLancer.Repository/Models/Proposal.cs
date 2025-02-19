using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class Proposal
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(50)]
        public string FreelancerName { get; set; } = null!;

        [Required, MaxLength(255)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0;
        public int HourDuration { get; set; } = 0;//For job hire by hour
        public int DeliveryTime { get; set; } = 1;//For the deadline result submission count in day
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(30)]
        public string Status { get; set; } = "Created";

        //======================[ Foreign Key ]======================
        public virtual Account Freelancer { get; set; } = null!;
        public virtual Category? Category { get; set; }
        public virtual Project? Project { get; set; }
        public virtual ICollection<ProposalSkill>? ProposalSkills { get; set; }
        public virtual ICollection<ProposalImage>? ProposalImages { get; set; }

        //public virtual ICollection<PersonalContracts>? PersonalContracts { get; set; }
    }
}
