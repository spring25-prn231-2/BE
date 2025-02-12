using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;

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
    }
}
