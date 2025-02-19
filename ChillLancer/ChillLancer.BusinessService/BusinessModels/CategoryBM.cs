using System.ComponentModel.DataAnnotations;

namespace ChillLancer.BusinessService.BusinessModels
{
    public class CategoryBM
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(100)]
        public string MajorName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string BriefName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string SpecializedName { get; set; } = null!;

        [MaxLength(30)]
        public string Status { get; set; } = "Created";
    }
}
