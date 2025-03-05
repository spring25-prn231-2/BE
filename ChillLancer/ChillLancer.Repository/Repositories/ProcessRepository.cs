using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ChillLancer.Repository.Repositories
{
    public class ProcessRepository(ChillLancerDbContext context) : GenericRepository<Process>(context), IProcessRepository
    {
        public async Task<List<Process>> GetProcessesByProposalId(Guid proposalId)
        => await context.Processes
                .Include(p => p.Proposal)
                .Where(p => p.Proposal.Id == proposalId).ToListAsync();
        public async Task<bool> UpdateProcesses(List<Process> processes)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                context.Processes.UpdateRange(processes);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<bool> DeleteProcesses(List<Process> processes)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                context.Processes.RemoveRange(processes);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

}
