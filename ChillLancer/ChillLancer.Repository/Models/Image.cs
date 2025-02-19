using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(200)]
        public string FileName { get; set; } = null!;
        [Required]
        public string Url { get; set; } = null!;
        public short OrderNum { get; set; } = 1;
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;

        //======================[ Foreign Key ]======================
        public virtual Account? User { get; set; }  //set as Avatar if not null
        public virtual ICollection<ProposalImage>? ProposalImages { get; set; }
    }
}
