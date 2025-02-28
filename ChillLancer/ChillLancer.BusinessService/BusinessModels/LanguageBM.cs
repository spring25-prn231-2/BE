using System.ComponentModel.DataAnnotations;

namespace ChillLancer.BusinessService.BusinessModels
{
    public class LanguageBM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(30)]
        public string Name { get; set; } = null!;
        [MaxLength(30)]
        public string? ProficiencyLevel { get; set; }
        [MaxLength(30)]
        public string Status { get; set; } = "Created";
        public Guid AccountId { get; set; } = Guid.Empty;
    }
}
