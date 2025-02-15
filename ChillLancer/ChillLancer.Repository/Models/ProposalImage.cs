namespace ChillLancer.Repository.Models
{
    public class ProposalImage
    {
        public Guid ProposalId { get; set; }
        public virtual Proposal Proposal { get; set; } = null!;

        public Guid ImageId { get; set; }
        public virtual Image Image { get; set; } = null!;
    }
}
