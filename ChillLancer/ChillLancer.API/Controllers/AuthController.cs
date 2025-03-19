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
        public async Task<ActionResult> Login([FromBody] LoginRequestModel loginRequest)
        {
            try
            {
                var account = await _accountService.Login(loginRequest.Email, loginRequest.Password);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestObjectResult(new
                {
                    message = ex.Message
                }));
            }

        }
        [HttpPost("/register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel registerRequest)
        {
            try
            {
                return Ok(await _accountService.Register(registerRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestObjectResult(new
                {
                    message = ex.Message
                }));
            }

        }
    }
}
