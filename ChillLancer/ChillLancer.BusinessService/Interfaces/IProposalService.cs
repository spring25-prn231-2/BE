using ChillLancer.BusinessService.BusinessModels;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface IProposalService
    {
        Task<bool> Add(ProposalBM inputData);
        Task<List<ProposalBM>> GetAll();
        Task<bool> Delete(Guid proposalId);
    }
}
