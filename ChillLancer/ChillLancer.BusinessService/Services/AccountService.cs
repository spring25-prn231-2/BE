using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions.Exceptions;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.BusinessService.Services.Auth;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.BusinessService.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        public AccountService(IAccountRepository accountRepository, IMapper mapper, IJwtService jwtService)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _jwtService = jwtService;
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

        public async Task<IActionResult> Login(string email, string password)
        {
            var loginedAccount = await _accountRepository.GetOneAsync(a => a.Email == email && a.Password == password);
            if (loginedAccount is null)
            {
                return new BadRequestObjectResult("Email or password is incorrect");
            }
            var token = _jwtService.GenerateToken(loginedAccount.Id, loginedAccount.Role);
            return new OkObjectResult(new
            {
                token = token //return token
            });  
        }

        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            try
            {
                var user = new Account
                {
                    Email = model.Email,
                    Password = model.Password,
                    NameTag = "",
                    FullName = ""
                };
                await _accountRepository.AddAsync(user);
                await _accountRepository.SaveChangeAsync();
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
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
