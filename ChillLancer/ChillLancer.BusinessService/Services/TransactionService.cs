﻿using ChillLancer.BusinessService.BusinessModels.Transaction;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.BusinessService.Service;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ChillLancer.BusinessService.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TransactionService> _logger;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly IProcessRepository _processRepository;


        public TransactionService(IConfiguration configuration, ITransactionRepository transactionRepository,
            ILogger<TransactionService> logger, IAccountRepository accountRepository, IProcessRepository processRepository)
        {
            _configuration = configuration;
            _logger = logger;
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _processRepository = processRepository;
        }
        public async Task<Transaction> AddPayment(TransactionResponseDTO paymentResponseDto)
        {
            try
            {
                if (paymentResponseDto == null)
                {
                    return null;
                }
                var existingEmployer = await _accountRepository.GetByIdAsync(paymentResponseDto.Employer?.Id);
                Transaction payment = new Transaction()
                {
                    Code = paymentResponseDto.Code ?? "",
                    BriefDescribe = paymentResponseDto.BriefDescribe ?? "",
                    StartDate = paymentResponseDto.StartDate == null ? null : paymentResponseDto.StartDate,
                    EndDate = paymentResponseDto.EndDate == null ? null : paymentResponseDto.EndDate,
                    HandleDate = DateTime.UtcNow,
                    Status = paymentResponseDto.Status ?? "",
                    FeePrice = paymentResponseDto.FeePrice,
                    TotalPrice = paymentResponseDto.TotalPrice,
                    Employer = existingEmployer ?? paymentResponseDto.Employer,
                    Type = "",
                    SystemFee =  new RateCode()
                    {
                        Id = new Guid(),
                        Code = "RC001",
                        Description = "Standard Rate",
                        Type = "Fixed",
                        Percentage=10.00M,
                        Status = "Active"
                    },
                    Freelancer = null,
                    Package = null

                };

                await _transactionRepository.AddAsync(payment);
                await _transactionRepository.SaveChangeAsync();
                return payment;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model, Guid userId)
        {
            try
            {
                var user = _accountRepository.GetAll().FirstOrDefault(e => e.Id == userId);
                var tick = DateTime.Now.Ticks.ToString();
                var vnpay = new VnPayLibrary();
                string payBackUrl = _configuration["VnPay:PaymentBackUrl"];

                vnpay.AddRequestData("vnp_Version", _configuration["VnPay:Version"]);
                vnpay.AddRequestData("vnp_Command", "pay");
                vnpay.AddRequestData("vnp_TmnCode", _configuration["VnPay:TmnCode"]);
                vnpay.AddRequestData("vnp_Amount", ((int)model.Amount * 100).ToString());

                vnpay.AddRequestData("vnp_CreateDate", model.CreatedDate.ToString("yyyyMMddHHmmss"));
                vnpay.AddRequestData("vnp_CurrCode", _configuration["VnPay:CurrCode"]);
                vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(context));
                vnpay.AddRequestData("vnp_Locale", _configuration["VnPay:Locale"]);
                vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + $"OrderId:{model.OrderId},Type:{model.Description},UserID:{userId},Amount:{model.Amount}");
                vnpay.AddRequestData("vnp_OrderType", "other");
                vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VnPay:PaymentBackUrl"]);
                vnpay.AddRequestData("vnp_TxnRef", model.OrderId.ToString());
                vnpay.AddRequestData("vnp_BankCode","NCB");

                TimeZoneInfo timeZone = TimeZoneInfo.Utc;
                DateTime utcTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, timeZone);
                // Thêm 7 giờ và 15 phút vào thời gian hiện tại
                DateTime expireTime = utcTime.AddHours(14).AddMinutes(1);
                // Định dạng thời gian theo yêu cầu
                string vnp_ExpireDate = expireTime.ToString("yyyyMMddHHmmss");
                vnpay.AddRequestData("vnp_ExpireDate", vnp_ExpireDate);

                var paymentUrl = vnpay.CreateRequestUrl(_configuration["VnPay:BaseUrl"], _configuration["VnPay:HashSecret"]);
                return paymentUrl;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public VnPaymentResponseModel PaymentExecute(Dictionary<string, string> url)
        {
            var vnpay = new VnPayLibrary();
            foreach (var (key, value) in url)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    vnpay.AddResponseData(key, value);
                }
            }
            // Lấy dữ liệu từ vnpay, sử dụng GetResponseData mà không cần gọi ToString() vì dữ liệu đã là string
            var vnp_OrderId = vnpay.GetResponseData("vnp_TxnRef");
            var vnp_Amount = vnpay.GetResponseData("vnp_Amount");
            var vnp_TransactionId = vnpay.GetResponseData("vnp_TransactionNo");
            var vnp_SecureHash = url.TryGetValue("vnp_SecureHash", out var secureHash) ? secureHash : string.Empty;
            var vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            var vnp_OrderInfo = vnpay.GetResponseData("vnp_OrderInfo");

            // Kiểm tra chữ ký
            bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, _configuration["VnPay:HashSecret"]);

            if (!checkSignature)
            {
                return new VnPaymentResponseModel
                {
                    Success = false,
                    //Message = "Invalid signature."
                };
            }

            // Chuyển đổi giá trị số lượng tiền từ chuỗi sang số (nếu cần)
            bool parseSuccess = decimal.TryParse(vnp_Amount, out decimal amount);

            return new VnPaymentResponseModel
            {
                Success = true,
                PaymentMethod = "VnPay",
                OrderDescription = vnp_OrderInfo,
                OrderId = vnp_OrderId,
                TransactionId = vnp_TransactionId,
                Token = vnp_SecureHash,
                Amount = (double)(parseSuccess ? amount : 0), // Sử dụng giá trị được phân tích nếu thành công, ngược lại sử dụng 0
                VnPayResponseCode = vnp_ResponseCode
            };
        }
        public string GetOrderId(string orderInfo)
        {
            string details = orderInfo.Substring(orderInfo.IndexOf(':') + 1);

            // Tách các cặp khóa-giá trị
            var keyValuePairs = details.Split(',');

            // Dictionary để lưu các cặp khóa-giá trị
            var dict = new Dictionary<string, string>();

            foreach (var pair in keyValuePairs)
            {
                var keyValue = pair.Split(':');
                if (keyValue.Length == 2)
                {
                    dict[keyValue[0].Trim()] = keyValue[1].Trim();
                }
            }

            // Lấy UserID và Amount từ dictionary
            if (dict.TryGetValue("OrderId", out string orderId))
            {
                return orderId;
            }
            else
            {
                return null;
            }
        }
        public string GetUserId(string orderInfo)
        {
            string details = orderInfo.Substring(orderInfo.IndexOf(':') + 1);

            // Tách các cặp khóa-giá trị
            var keyValuePairs = details.Split(',');

            // Dictionary để lưu các cặp khóa-giá trị
            var dict = new Dictionary<string, string>();

            foreach (var pair in keyValuePairs)
            {
                var keyValue = pair.Split(':');
                if (keyValue.Length == 2)
                {
                    dict[keyValue[0].Trim()] = keyValue[1].Trim();
                }
            }

            // Lấy UserID và Amount từ dictionary
            if (dict.TryGetValue("UserID", out string userId))
            {
                return userId;
            }
            else
            {
                return null;
            }
        }
    }
}
