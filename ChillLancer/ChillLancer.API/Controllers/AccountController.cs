using ChillLancer.BusinessService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        //=================================[ Declares ]================================
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //=================================[ Endpoints ]================================
        [HttpGet("test-di")]
        public async Task<IActionResult> TestConnect()
        {
            return Ok(await _accountService.CallRepository());
        }
    }
}
