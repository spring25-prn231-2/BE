using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class ProposalSkill
    {
        public Guid ProposalId { get; set; }
        public virtual Proposal Proposal { get; set; } = null!;

        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; } = null!;

        [Required, MaxLength(30)]
        public string Level { get; set; } = null!;
    }
}
