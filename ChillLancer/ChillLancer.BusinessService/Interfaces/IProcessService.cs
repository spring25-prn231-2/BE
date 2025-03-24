using ChillLancer.BusinessService.BusinessModels;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface IProcessService
    {
        //Task<bool> Add(List<ProcessBM> inputData);
        Task<bool> Update(List<ProcessUpdateBM> inputData, Guid proposalId);
        Task<bool> Delete(List<ProcessUpdateBM> inputData, Guid proposalId);
        Task<List<ProcessBM>> GetProcessbyProposalId(Guid proposalId);
    }
}
