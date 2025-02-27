using System.ComponentModel.DataAnnotations;

namespace ChillLancer.BusinessService.BusinessModels
{
    public class CertificationBM
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(30)]
        public string Name { get; set; } = null!;
        [Required, MaxLength(100)]
        public string AchieveFrom { get; set; } = null!;
        public short YearAchieved { get; set; } = 1900;
        [MaxLength(30)]
        public string Status { get; set; } = "Created";
        public Guid FreeLancerId { get; set; } = Guid.Empty;
    }
}
