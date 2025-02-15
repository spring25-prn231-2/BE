namespace FP_API.src.Domain.Entities
{
    public class Education
    {
        public Guid Id { get; set; }
        public string UniversityName { get; set; } = null!;
        public int YearGraduation { get; set; }
        public Guid FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; } = null!;
    }
}
