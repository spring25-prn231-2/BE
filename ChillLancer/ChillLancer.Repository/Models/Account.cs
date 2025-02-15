﻿namespace ChillLancer.Repository.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = "Customer";
        public string Status { get; set; } = "Created";
    }
}
