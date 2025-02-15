namespace FP_API.src.Domain.Entities
{
    public class FreelancerSkill
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int YearExperience { get; set; }
        public Guid? SkillId { get; set; }
        public Guid FreelancerId { get; set; }
        public Skill Skill { get; set; } = null!;
        public Freelancer Freelancer { get; set; } = null!;
    }
}
