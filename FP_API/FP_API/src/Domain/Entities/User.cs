namespace FP_API.src.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int RoleId { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}
