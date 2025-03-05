using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository;
using ChillLancer.Repository.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        //=================================[ Declares ]================================
        private readonly IAccountService _accountService;
        private readonly ChillLancerDbContext _context;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, ChillLancerDbContext context, IMapper mapper)
        {
            _accountService = accountService;
            _context = context;
            _mapper = mapper;
        }

        //=================================[ Endpoints ]================================
        [HttpGet("test-di")]
        public async Task<IActionResult> TestConnect()
        {
            return Ok(await _accountService.CallRepository());
        }
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            return Ok(await _accountService.GetAccounts());
        }
        [EnableQuery]
        [HttpGet("odata")]
        public IEnumerable<AccountBM> GetUsersOdata()
        {
            var account = _context.Accounts.AsEnumerable();
            var mappedAccount = _mapper.Map<IEnumerable<AccountBM>>(account);
            return mappedAccount;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(Guid id)
        {
            return Ok(await _accountService.GetAccount(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountCreateBM account)
        {
            return Ok(await _accountService.CreateAccount(account));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAccount(AccountUpdateBM account)
        {
            return Ok(await _accountService.UpdateAccount(account));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            return Ok(await _accountService.DeleteAccount(id));
        }
    }
}
