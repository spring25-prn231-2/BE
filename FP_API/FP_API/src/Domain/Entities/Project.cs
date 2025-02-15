namespace FP_API.src.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid ManagerId { get; set; }
        public User Manager { get; set; } = null!;
        public List<Milestone> Milestones { get; set; } = new();
        public List<Proposal>? Proposals { get; set; }
        public List<ProjectSkill> ProjectSkills { get; set; } = new();
    }
}
