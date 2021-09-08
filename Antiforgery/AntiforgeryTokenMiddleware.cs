using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Antiforgery
{
    public class AntiforgeryTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAntiforgery _antiforgery;

        public AntiforgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
        {
            _next = next;
            _antiforgery = antiforgery;
        }

        public Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.Value.ToLower();
            string[] directUrls = { "/path1", "/weatherforecast" };
            //if (path.StartsWith("/api") || directUrls.Any(url => path.StartsWith(url)))
            if(path.ToLower().Contains("generatebyendpoint"))
            {
                var tokens = _antiforgery.GetAndStoreTokens(context);


                context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                    new CookieOptions()
                    {
                        // only sent with HTTPS and not HTTP,  All HTTP (Not HTTPS) requests will fail and return a 400 response
                        HttpOnly = false,
                        // The cookie should be secure but readable using javascript (non - httpOnly).
                        Secure = true,
                        IsEssential = true,
                        SameSite = SameSiteMode.None,
                        Path = "/"
                    });
            }

            return _next(context);
        }
    }

    public static class AntiforgeryTokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseAntiforgeryToken(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AntiforgeryTokenMiddleware>();
        }
    }
}
