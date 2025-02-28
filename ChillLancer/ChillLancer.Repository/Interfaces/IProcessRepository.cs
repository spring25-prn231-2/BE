using ChillLancer.Repository.Models;

namespace ChillLancer.Repository.Interfaces
{
    public interface IProcessRepository : IGenericRepository<Process>
    {
        Task<Proposal> GetProposalById(Guid proposalId);
    }
}
