﻿using System.ComponentModel.DataAnnotations;

namespace ChillLancer.BusinessService.BusinessModels
{
    public class ProjectBM
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(150, ErrorMessage = "Title cannot exceed 150 characters.")]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Guidelines { get; set; }
        [Required(ErrorMessage = "Budget is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Budget must be greater than 0.")]
        public decimal Budget { get; set; } = 0;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; } = 1;
        public string? RequirementNote { get; set; }
        public string Status { get; set; } = "Created";
      
        [Required(ErrorMessage ="employer id is required.")]
        public AccountBM Employer { get; set; }

        [Required(ErrorMessage = "category id is required.")]
        public CategoryBM Category { get; set; } = null!;
        public ICollection<SkillBM>? ProjectSkills { get; set; }
        public Guid? EmployerId { get; set; }

        [Required(ErrorMessage = "category id is required.")]
        public Guid? CategoryId { get; set; }

        public ICollection<Guid>? skillIds { get; set; }
    }

    public class ProjectCreateBM
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(150, ErrorMessage = "Title cannot exceed 150 characters.")]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int Duration { get; set; }
        public string? Guidelines { get; set; }
        [Required(ErrorMessage = "Budget is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Budget must be greater than 0.")]
        public decimal Budget { get; set; } = 0;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? RequirementNote { get; set; }
        public string Status { get; set; } = "Created";

        [Required(ErrorMessage = "employer id is required.")]

        public Guid? EmployerId { get; set; }

        [Required(ErrorMessage = "category id is required.")]
        public Guid? CategoryId { get; set; }

        public ICollection<Guid>? skillIds { get; set; }
    }
}
