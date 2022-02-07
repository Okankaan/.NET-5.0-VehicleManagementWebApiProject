using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using VMBusiness.Constants;
using VMEntities.VMDBEntities;

namespace VMAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IMemoryCache cache;
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            semaphore.Wait();
            try
            {
                cache = (IMemoryCache)context.HttpContext.RequestServices.GetService(typeof(IMemoryCache));
                var userClaims = ((System.Security.Claims.ClaimsIdentity)context.HttpContext.User.Identity).Claims;
                foreach (var claim in userClaims)
                {
                    if (claim.Type.Equals("username"))
                    {
                        var jwtCacheParam = cache.Get(claim.Value);
                        if (jwtCacheParam != null)
                        {
                            var cacheUserName = ((VMEntities.JWT.JwtCache)jwtCacheParam).Token.RefreshToken.UserName;
                            if (cacheUserName != claim.Value)
                            {
                                context.Result = new JsonResult(new { Success = false, Message = ConstantMessages.TokenIsNotValid }) { StatusCode = StatusCodes.Status401Unauthorized };
                                return;
                            }
                        }
                        else
                        {
                            context.Result = new JsonResult(new { Success = false, Message = ConstantMessages.TokenIsNotValid }) { StatusCode = StatusCodes.Status401Unauthorized };
                            return;
                        }
                    }
                }
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
