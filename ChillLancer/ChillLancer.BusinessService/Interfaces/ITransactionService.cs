using ChillLancer.BusinessService.BusinessModels.Transaction;
using ChillLancer.Repository.Models;
using Microsoft.AspNetCore.Http;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface ITransactionService
    {
        Task<string> CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model, Guid userId);
        Task<Transaction> AddPayment(TransactionResponseDTO paymentResponseDto);
        VnPaymentResponseModel PaymentExecute(Dictionary<string, string> url);
        string GetOrderId(string orderInfo);
        string GetUserId(string orderInfo);
    }
}
