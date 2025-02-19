using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class Certification
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(30)]
        public string Name { get; set; } = null!;
        [Required, MaxLength(100)]
        public string AchieveFrom { get; set; } = null!;
        public short YearAchieved { get; set; } = 1900;
        [MaxLength(30)]
        public string Status { get; set; } = "Created";

        //======================[ Foreign Key ]======================
        public virtual Account Freelancer { get; set; } = null!;
    }
}
