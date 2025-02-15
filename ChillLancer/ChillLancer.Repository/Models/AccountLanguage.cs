using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class AccountLanguage
    {
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; } = null!;

        public Guid LanguageId { get; set; }
        public virtual Language Language { get; set; } = null!;

        [Required, MaxLength(30)]
        public string ProficiencyLevel {get; set;} = null!;
    }
}
