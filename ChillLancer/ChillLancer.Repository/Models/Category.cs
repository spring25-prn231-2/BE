using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class Category
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

        //======================[ Foreign Key ]======================
        public virtual ICollection<Project>? Projects { get; set; }
        public virtual ICollection<Proposal>? Proposals { get; set; }
    }
}
