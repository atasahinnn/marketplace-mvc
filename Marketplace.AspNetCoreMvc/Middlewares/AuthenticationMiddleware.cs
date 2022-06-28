using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Marketplace.Business.Concrete.Utilies.Security;
using Marketplace.Business.Concrete.Utilies.Security.Encryptions;

namespace Marketplace.AspNetCoreMvc.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                var cookie = httpContext.Request.Cookies["authCookie"];

                if (!string.IsNullOrEmpty(cookie))
                {
                    var userData = Encryption.DecryptString(cookie);

                    var identity = WebAuthenticationHelper.AuthCookieToIdentity(userData);

                    var principal = new GenericPrincipal(identity, identity.Roles);

                    httpContext.User = principal;

                    Thread.CurrentPrincipal = principal;
                }

            }
            catch
            {

            }


            await _next.Invoke(httpContext);
        }
    }

    public static class AuthenticationMiddlewareExtension
    {
        public static IApplicationBuilder UseHeaderCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
