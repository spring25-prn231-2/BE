using ChillLancer.Repository.Models;

namespace ChillLancer.Repository.Interfaces
{
    public interface IProposalRepository : IGenericRepository<Proposal>
    {
        //Task<List<Proposal>> GetAllAsync();
        Task<List<Proposal>> GetAll();
        Task<List<Proposal>> GetProposalsByAccount(Guid accountId);
        Task<Project> GetProjectById(Guid projectId);
        Task<Account> GetAccountById(Guid accountId);
    }
}
