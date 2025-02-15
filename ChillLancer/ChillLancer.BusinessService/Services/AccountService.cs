using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;

namespace ChillLancer.BusinessService.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        //=============================================================================

        public async Task<bool> CallRepository()
        {
            return await _accountRepository.CallDb();
        }
    }
}
