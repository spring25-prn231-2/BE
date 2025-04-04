using ChillLancer.BusinessService.BusinessModels;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface IProposalService
    {
        Task<bool> Add(ProposalBM inputData);
        Task<List<ProposalBM>> GetAll();
        Task<List<ProposalBM>> GetProposalsByProjectId(Guid projectId);
        Task<bool> Delete(Guid proposalId);
        Task<bool> AcceptProposal(Guid proposalId);
        Task<bool> CheckAcceptedProposal(Guid projectId);
        Task<List<ProposalBM>> getALlProposalsByAccountId(Guid accountId);
    }
}
