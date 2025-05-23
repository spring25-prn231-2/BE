﻿using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.BusinessService.Middleware;
using ChillLancer.BusinessService.Services.Auth;
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
            return Ok(new OkObjectResult(new
            {
                data = await _accountService.GetAccounts()
            }));
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
        [Protected]
        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountCreateBM account)
        {
            return Ok(await _accountService.CreateAccount(account));
        }
        [Protected]
        [HttpPut]
        public async Task<IActionResult> UpdateAccount(AccountUpdateBM account)
        {
            return Ok(await _accountService.UpdateAccount(account));
        }
        [Protected]
        [HttpDelete("{id}")]
        [Permission("ACCOUNT.ALL")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            return Ok(await _accountService.DeleteAccount(id));
        }
        [Protected]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                var payload = HttpContext.Items["payload"] as Payload;
                if (payload == null)
                {
                    return Unauthorized();
                }
                var account = await _accountService.GetAccount(payload.UserId);
                return Ok(new OkObjectResult(new
                {
                    data = account
                }));

            }
            catch (Exception ex)
            {
                return BadRequest(new OkObjectResult(new
                {
                    message = ex.Message,
                }));
            }
        }
        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetAccountByProjectId(Guid projectId)
        {
            var payload = await _accountService.GetAccountByProjectId(projectId);
            if (payload == null)
                return NotFound();
            return Ok(payload);
        }
    }
}
