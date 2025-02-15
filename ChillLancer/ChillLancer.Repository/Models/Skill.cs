using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class Skill
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        [MaxLength(30)]
        public string Status { get; set; } = "Created";

        //======================[ Foreign Key ]======================
        public virtual ICollection<ProjectSkill>? ProjectSkills { get; set; }
        public virtual ICollection<ProposalSkill>? ProposalSkill { get; set; }
    }
}
