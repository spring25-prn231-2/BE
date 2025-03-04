using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.Repository.Models;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CallRepository();
        Task<IEnumerable<AccountBM>> GetAccounts();
        Task<AccountBM> GetAccount(Guid Id);
        Task<bool> CreateAccount(AccountCreateBM account);
        Task<bool> UpdateAccount(AccountUpdateBM account);
        Task<bool> DeleteAccount(Guid Id);
        IQueryable<AccountBM> GetAccountsOdata();
    }
}
