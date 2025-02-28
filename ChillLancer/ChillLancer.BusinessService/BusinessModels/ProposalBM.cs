using ChillLancer.Repository.Models;

namespace ChillLancer.BusinessService.BusinessModels
{
    public class ProposalBM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FreelancerName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int HourDuration { get; set; }
        public int DeliveryTime { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Created";
        public Guid ProjectId { get; set; } = Guid.Empty;
        public Guid AccountId { get; set; }
        public List<ProcessBM> Processes { get; set; } = [];

    }
}
