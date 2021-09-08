using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Antiforgery
{
    public class AntiForgeryTokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryTokenValidationMiddleware(RequestDelegate next, IAntiforgery antiforgery)
        {
            _next = next;
            _antiforgery = antiforgery;
        }

        public async Task Invoke(HttpContext context)
        {
            // just validate POST request
            if (HttpMethods.IsPost(context.Request.Method))
            {
                await _antiforgery.ValidateRequestAsync(context);
            }

            await _next(context);
        }
    }

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAntiforgeryTokensValidation(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AntiForgeryTokenValidationMiddleware>();
        }
    }
}
