using ChillLancer.BusinessService.Services.Auth;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ChillLancer.Repository.Interfaces;

namespace ChillLancer.BusinessService.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class PermissionAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _permission;

        public PermissionAttribute(params string[] permission)
        {
            _permission = permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Task.Run(async () => await OnAuthorizationAsync(context)).Wait();
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var serviceProvider = context.HttpContext.RequestServices;
            var roleBaseRepository = serviceProvider.GetService<IRoleRepository>();
            try
            {
                // check payload
                var isForbidden = true;
                var payload = context.HttpContext.Items["payload"] as Payload;
                if (payload == null)
                {
                    isForbidden = true;
                    context.Result = new JsonResult(new
                    {
                        StatusCode = 401,
                        Message = "Unauthorized",
                        IsSuccess = false
                    });
                    return;
                }
                // check service
                if (roleBaseRepository == null)
                {
                    context.Result = new JsonResult(new
                    {
                        StatusCode = 500,
                        Message = "Service not available",
                        IsSuccess = false
                    });
                    return;
                }
                // check permission
                else
                {
                    var PermissionRole = roleBaseRepository.GetPermissionSlugsByRoleId(payload.Role);
                    foreach (var permission in _permission)
                    {
                        if (PermissionRole.Contains(permission))
                        {
                            isForbidden = false;
                            break;
                        }
                    }
                }
                if (isForbidden)
                {
                    context.Result = new JsonResult(new
                    {
                        StatusCode = 403,
                        Message = "Forbidden",
                        IsSuccess = false
                    });
                }

            }
            catch (Exception)
            {
                context.Result = new JsonResult(new
                {
                    StatusCode = 500,
                    Message = "Internal Server Error",
                    IsSuccess = false
                });
            }
        }
    }
}
