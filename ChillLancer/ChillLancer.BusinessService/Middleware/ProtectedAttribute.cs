using ChillLancer.BusinessService.Services.Auth;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.BusinessService.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ProtectedAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IJwtService _jwtService;

        public ProtectedAttribute()
        {
            _jwtService = new JwtService();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                // Trả về sớm nếu token không có hoặc không đúng định dạng
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new JsonResult(new
                {
                    StatusCode = 401,
                    Message = "Unauthorized",
                    IsSuccess = false
                });
                return;
            }

            var token = authorizationHeader.Replace("Bearer ", "");

            try
            {
                var payload = _jwtService.ValidateToken(token);
                context.HttpContext.Items["payload"] = payload;
            }
            catch (Exception ex)
            {
                context.Result = new JsonResult(new
                {
                    StatusCode = 401,
                    Message = ex.Message,
                    IsSuccess = false
                });
                return;
            }
        }

    }
}
