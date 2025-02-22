using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChillLancer.Repository.Models
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(150)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Guidelines { get; set; }
        public decimal Budget { get; set; } = 0;
        public int Duration { get; set; } = 1;//How many days to work from start date
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? RequirementNote { get; set; }

        [MaxLength(30)]
        public string Status { get; set; } = "Created";

        //======================[ Foreign Key ]======================
        public virtual Category Category { get; set; } = null!;
        public virtual Account Employer { get; set; } = null!;
        public virtual ICollection<ProjectSkill>? ProjectSkills { get; set; }
        public virtual ICollection<ProjectContract>? ProjectContracts { get; set; }
        public virtual ICollection<Proposal>? Proposals { get; set; }
    }
}
