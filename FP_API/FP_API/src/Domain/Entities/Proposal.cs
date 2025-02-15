namespace FP_API.src.Domain.Entities
{
    public class Proposal
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid FreelancerId { get; set; }
        public int BidAmount { get; set; }
        public enum ProposalEnum
        {
            Pending,
            Accepted
        }
        public ProposalEnum Status { get; set; }
        public Project Project { get; set; } = null!;
        public Freelancer Freelancer { get; set; } = null!;
    }
}
