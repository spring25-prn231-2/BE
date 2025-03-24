using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ChillLancer.Repository.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly ChillLancerDbContext _context;
        public AccountRepository(ChillLancerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CallDb()
        {
            return true;
        }
        public IQueryable<Account> GetAccountsQuery()
        {
            return _context.Accounts.AsQueryable();
        }
        public async Task<Account> GetAccountByProjectId(Guid id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(acc => acc.Projects.Any(p => p.Id == id));
        }
    }
}
