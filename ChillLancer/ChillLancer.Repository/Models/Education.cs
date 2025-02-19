using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class Education
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(100)]
        public string Country { get; set; } = null!;

        [Required, MaxLength(100)]
        public string SchoolName { get; set; } = null!;

        [Required, MaxLength(255)]
        public string Major { get; set; } = null!;

        [Required, MaxLength(30)]
        public string ProficiencyLevel { get; set; } = null!;

        [Required, MaxLength(30)]
        public string DegreeType { get; set; } = null!;
        public short YearGraduation { get; set; } = 1900;
        [MaxLength(30)]
        public string Status { get; set; } = "Created";

        //======================[ Foreign Key ]======================
        public virtual Account Freelancer { get; set; } = null!;
    }
}
