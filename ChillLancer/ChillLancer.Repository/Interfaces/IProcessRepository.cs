using ChillLancer.Repository.Models;

namespace ChillLancer.Repository.Interfaces
{
    public interface IProcessRepository : IGenericRepository<Process>
    {
        Task<List<Process>> GetProcessesByProposalId(Guid proposalId);
        Task<bool> UpdateProcesses(List<Process> processes);
        Task<bool> DeleteProcesses(List<Process> processes);
    }
}
