using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class Language
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(30)]
        public string Name { get; set; } = null!;
        [MaxLength(30)]
        public string Status { get; set; } = "Created";

        //======================[ Foreign Key ]======================
        public virtual ICollection<AccountLanguage>? AccountLanguages { get; set; }
    }
}
