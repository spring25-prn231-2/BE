using ChillLancer.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.BusinessService.BusinessModels
{
    public class ProjectBM
    {
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
        public string? RequirementNote { get; set; }
        public string Status { get; set; } = "Created";

        [Required(ErrorMessage ="employer id is required.")]
        public Guid? employerId { get; set; }

        [Required(ErrorMessage = "category id is required.")]
        public Guid? categoryId { get; set; }
    }
}
