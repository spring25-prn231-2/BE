﻿using System.ComponentModel.DataAnnotations;

namespace ChillLancer.Repository.Models
{
    public class Process
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(150)]
        public string TaskName { get; set; } = null!;
        public string? TaskDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Cost { get; set; } = 0;
        public bool IsPaid { get; set; } = false;
        public string? Note { get; set; }
        public string Status { get; set; } = "Draft";

        //======================[ Foreign Key ]======================
        public virtual Proposal Proposal { get; set; } = null!;
    }
}
