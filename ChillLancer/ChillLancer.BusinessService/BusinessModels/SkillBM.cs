using System.ComponentModel.DataAnnotations;

namespace ChillLancer.BusinessService.BusinessModels
{
    public class SkillBM
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        [MaxLength(30)]
        public string Status { get; set; } = "Created";

        [MaxLength(30)]
        public string? Level { get; set; }
        public Guid ProjectId { get; set; } = Guid.Empty;
        public Guid ProposalId { get; set; } = Guid.Empty;
    }
}
