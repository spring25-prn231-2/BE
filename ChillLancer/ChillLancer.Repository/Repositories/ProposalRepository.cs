using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ChillLancer.Repository.Repositories
{
    public class ProposalRepository(ChillLancerDbContext context) : GenericRepository<Proposal>(context), IProposalRepository
    {
        public async Task<List<Proposal>> GetAll()
        {
            return await GetListAsync(x => true, x => x.Freelancer, x => x.Project);
        }
        public async Task<List<Proposal>> GetProposalsByAccount(Guid accountId)
        {
            return await context.Proposals
                .Include(x => x.Freelancer)
                .Where(x => x.Freelancer.Id == accountId).ToListAsync();
        }
        public async Task<List<Proposal>> GetProposalsByProjectId(Guid projectId)
        {
            return await context.Proposals
                .Include(x => x.Freelancer)
                .Where(x => x.Project.Id == projectId).ToListAsync();
        }
        public async Task<Project> GetProjectById(Guid projectId) 
            => await context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
        public async Task<Account> GetAccountById(Guid accountId)
            => await context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
        public async Task<Proposal> GetProposalById(Guid proposalId)
            => await context.Proposals.FirstOrDefaultAsync(p => p.Id == proposalId);
    }
}
