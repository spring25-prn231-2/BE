using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Mapster;
using MapsterMapper;

namespace ChillLancer.BusinessService.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        //=============================================================================

        public async Task<bool> CallRepository()
        {
            return await _accountRepository.CallDb();
        }

        public async Task<bool> CreateAccount(AccountCreateBM account)
        {
            var newAccount = _mapper.Map<Account>(account);
            await _accountRepository.AddAsync(newAccount);
            return await _accountRepository.SaveChangeAsync();
        }

        public async Task<bool> DeleteAccount(Guid Id)
        {
            var accountToDelete = await _accountRepository.GetByIdAsync(Id) ?? throw new Exception("Account not found");
            await _accountRepository.DeleteAsync(accountToDelete);
            return await _accountRepository.SaveChangeAsync();
        }

        public async Task<AccountBM> GetAccount(Guid Id)
        {
            var account = await _accountRepository.GetByIdAsync(Id) ?? throw new Exception("Account not found");
            return _mapper.Map<AccountBM>(account);
        }

        public async Task<IEnumerable<AccountBM>> GetAccounts()
        {
            var accounts = await _accountRepository.GetListAsync(acc => true);  // Hoặc có thể bỏ điều kiện lọc nếu không cần thiết
            return _mapper.Map<IEnumerable<AccountBM>>(accounts);
        }
        public IQueryable<AccountBM> GetAccountsOdata()
        {
            var accounts = _accountRepository.GetAccountsQuery() ?? throw new Exception("Account not found");
            var mappedAccount = _mapper.Map<IQueryable<AccountBM>>(accounts);
            return mappedAccount;
        }

        public async Task<bool> UpdateAccount(AccountUpdateBM account)
        {
            var accountToUpdate = await _accountRepository.GetByIdAsync(account.Id) ?? throw new Exception("Account not found");
            var mappedAccount = _mapper.Map(account, accountToUpdate);
            await _accountRepository.UpdateAsync(mappedAccount!);
            return await _accountRepository.SaveChangeAsync();
        }
    }
}
