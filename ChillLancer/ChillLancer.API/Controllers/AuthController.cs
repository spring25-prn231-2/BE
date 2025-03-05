using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountBM>> Login([FromBody] LoginRequestModel loginRequest)
        {
            var account = await _accountService.Login(loginRequest.Email, loginRequest.Password);
            if (account is null) return NotFound();

            return Ok(account);
        }
    }
}
