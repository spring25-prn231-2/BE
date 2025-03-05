namespace ChillLancer.Repository.Models
{
    public class ProjectSkill
    {
        public Guid ProjectId { get; set; }
        public virtual Project? Project { get; set; } = null!;

        public Guid SkillId { get; set; }
        public virtual Skill? Skill { get; set; } = null!;
    }
}
