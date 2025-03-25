using ChillLancer.BusinessService.BusinessModels.Transaction;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Models;
using Mapster;
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
        private readonly IProposalService _proposalService;
        private readonly IProcessService _processService;

        public TransactionController(
            ITransactionService transactionService,
            IAccountService accountService,
            IProposalService proposalService,
            IProcessService processService
            )
        {
            _transactionService = transactionService;
            _accountService = accountService;
            _proposalService = proposalService;
            _processService = processService;
        }
        /// <summary>
        /// Create url
        /// </summary>
        [HttpPost("payment/vnpay")]
        public async Task<IActionResult> AddPayment(Guid orderId, Guid userId)
        {
            var user = await _accountService.GetAccount(userId);
            var process = await _processService.GetProcessById(orderId);
            try
            {
                var vnPayModel = new VnPaymentRequestModel()
                {
                    Amount = process.Cost,
                    CreatedDate = DateTime.Now,
                    Description = "thanh toán VnPay",
                    OrderId = process.Id,
                };
                if (vnPayModel.Amount < 0)
                {
                    return BadRequest("The amount entered cannot be less than 0. Please try again");
                }
                var paymentUrl = await _transactionService.CreatePaymentUrl(HttpContext, vnPayModel, user.Id);
                return Ok(new { url = paymentUrl });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("PaymentBack")]
        public async Task<IActionResult> PaymenCalltBack()
        {
            var queryParameters = HttpContext.Request.Query;
            string orderInfo = queryParameters["vnp_OrderInfo"];
            string responseCode = queryParameters["vnp_ResponseCode"];

            if (string.IsNullOrEmpty(orderInfo))
            {
                return BadRequest("Invalid info");
            }


            string userId = _transactionService.GetUserId(orderInfo);
            string orderId = _transactionService.GetOrderId(orderInfo);

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(orderId))
            {
                return BadRequest("missing info");
            }

            Guid processId;
            if (!Guid.TryParse(orderId, out processId))
            {
                return BadRequest("processId invalid");
            }

            if (responseCode != "00")
            {
                var updateResult = await _processService.UpdateStatus("Done", processId);
                if (updateResult)
                {
                    return Redirect("https://localhost:7005/Payment/PaymentFailed");
                }
                return BadRequest("Error");
            }


            if (!decimal.TryParse(queryParameters["vnp_Amount"], out decimal amount))
            {
                return BadRequest("Invalid money");
            }

            if (string.IsNullOrEmpty(orderInfo))
            {
                return BadRequest("not existed info");
            }
            var orderInfoDict = new Dictionary<string, string>();
            string[] pairs = orderInfo.Split(',');
            foreach (var pair in pairs)
            {
                string[] keyValue = pair.Split(':');
                if (keyValue.Length == 2)
                {
                    orderInfoDict[keyValue[0].Trim()] = keyValue[1].Trim();
                }
            }
            Guid employerId;
            if (!Guid.TryParse(userId, out employerId))
            {
                return BadRequest($"Could not find {userId}");
            }
            var employer = await _accountService.GetAccount(employerId);
            var paymentDto = new TransactionResponseDTO()
            {
                Employer = employer.Adapt<Account>(),
                Type = orderId,
                Status = "SUCCESS",
                TotalPrice = amount,
                PayMethod = "VnPay",
                StartDate = DateTime.UtcNow.AddHours(7),
            };

            var process = _processService.GetProcessById(processId);
            if (process == null)
            {
                return BadRequest("process not found");
            }

            var result = await _transactionService.AddPayment(paymentDto);

            if (result is not null)
            {
                var updateResult = await _processService.UpdateStatus("Paid", processId);
                if (updateResult)
                {
                    return Redirect("https://localhost:7005/Payment/PaymentSuccess");
                }
                return BadRequest("update Invalid");
            }
            else
            {
                return BadRequest("Invalid transaction data.");
            }
        }
    }
}
