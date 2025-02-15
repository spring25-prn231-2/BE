namespace FP_API.src.Domain.Entities
{
    public class Freelancer : User
    {
        public Freelancer()
        {
            RoleId = 2; // khởi tạo freelancer roleId = 2
        }
        public string? CvUrl { get; set; }
        public List<Education> Educations { get; set; }
        public List<Certification> Certifications { get; set; }
    }
}
