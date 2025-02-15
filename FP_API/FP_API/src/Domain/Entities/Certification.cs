namespace FP_API.src.Domain.Entities
{
    public class Certification
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? FileUrl { get; set; }
        public Guid FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; } = null!;
    }
}
