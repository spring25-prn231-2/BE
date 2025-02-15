namespace FP_API.src.Domain.Entities
{
    public class ProjectSkill
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int YearExperience { get; set; }
        public Guid? SkillId { get; set; }
        public Guid ProjectId { get; set; }
        public Skill Skill { get; set; } = null!;
        public Project Project { get; set; } = null!;
    }
}
