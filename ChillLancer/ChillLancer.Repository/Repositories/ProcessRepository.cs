using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ChillLancer.Repository.Repositories
{
    public class ProcessRepository(ChillLancerDbContext context) : GenericRepository<Process>(context), IProcessRepository
    {
        public async Task<Proposal> GetProposalById(Guid proposalId)
            => await context.Proposals.FirstOrDefaultAsync(p => p.Id == proposalId);
    }
}
