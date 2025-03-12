using System.ComponentModel.DataAnnotations;

namespace ChillLancer.BusinessService.BusinessModels
{
    public class AccountBM
    {
        public Guid Id { get; set; }
        public string? AvatarUrl { get; set; }
        public string? FirebaseUid { get; set; }
        public string? FcmToken { get; set; }
        public string? GoogleId { get; set; }
        public string? FacebookId { get; set; }
        public string NameTag { get; set; } = null!;
        public string? IdentityCode { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? National { get; set; }
        public string? BioSummary { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyWebsite { get; set; }
        public int Favorited { get; set; } = 0;
        public int Liked { get; set; } = 0;
        public int Dislike { get; set; } = 0;
        public bool IsVerified { get; set; } = false;
        public DateTime? LastDelivery { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
        public string Role { get; set; } = "Customer";
        public string Status { get; set; } = "Created";
    }
    public class AccountCreateBM
    {
        //public string? AvatarUrl { get; set; }
        //public string? FirebaseUid { get; set; }
        //public string? FcmToken { get; set; }
        //public string? GoogleId { get; set; }
        //public string? FacebookId { get; set; }

        [Required, MaxLength(100)]
        public string NameTag { get; set; } = "";

        //[MaxLength(30)]
        //public string? IdentityCode { get; set; }

        [Required, MaxLength(50)]
        public string FullName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Email { get; set; } = null!;

        //[Required]
        //public string Password { get; set; } = null!;

        //[MaxLength(15)]
        //public string? PhoneNumber { get; set; }
        //public string? Address { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        //[MaxLength(20)]
        //public string? Gender { get; set; }
        //[MaxLength(100)]
        //public string? National { get; set; }
        //public string? BioSummary { get; set; }
        //[MaxLength(200)]
        //public string? CompanyName { get; set; }
        //[MaxLength(255)]
        //public string? CompanyWebsite { get; set; }
        //public DateTime? LastDelivery { get; set; }
        [MaxLength(30)]
        public string Role { get; set; } = null!;
    }
    public class AccountUpdateBM
    {
        [Required]
        public Guid Id { get; set; }
        public string? AvatarUrl { get; set; }
        public string? FirebaseUid { get; set; }
        public string? FcmToken { get; set; }
        public string? GoogleId { get; set; }
        public string? FacebookId { get; set; }

        [Required, MaxLength(100)]
        public string? NameTag { get; set; }

        [MaxLength(30)]
        public string? IdentityCode { get; set; }

        [Required, MaxLength(50)]
        public string? FullName { get; set; } = null!;

        //[Required, MaxLength(100)]
        //public string Email { get; set; } = null!;

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(20)]
        public string? Gender { get; set; }
        [MaxLength(100)]
        public string? National { get; set; }
        public string? BioSummary { get; set; }
        [MaxLength(200)]
        public string? CompanyName { get; set; }
        [MaxLength(255)]
        public string? CompanyWebsite { get; set; }
        public DateTime? LastDelivery { get; set; }
    }
}
