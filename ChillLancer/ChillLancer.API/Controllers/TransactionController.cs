using ChillLancer.BusinessService.BusinessModels.Transaction;
using ChillLancer.BusinessService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;

        public TransactionController(
            ITransactionService transactionService,
            IAccountService accountService
            )
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }
    }
}
