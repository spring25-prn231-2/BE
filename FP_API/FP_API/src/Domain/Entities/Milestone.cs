namespace FP_API.src.Domain.Entities
{
    public class Milestone
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
    }
}
