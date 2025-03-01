using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAccountService _accountService;
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost("/login")]
        //[AllowAnonymous]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesErrorResponseType(typeof(ApiResponseModel<string>))]
        //public async Task<ActionResult<Account>> Login(string email, string password)
        //{
        //    var account = await _accountService.Login(email, password);
        //    if (account is null) return NotFound();

        //    return Ok(account);
        //}
    }
}
