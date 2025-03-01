using ChillLancer.Repository.Models;

namespace ChillLancer.Repository.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<bool> CallDb();

        public IQueryable<Account> GetAccountsQuery();
    }
}
