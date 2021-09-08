using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

namespace Antiforgery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AntiForgeryController : Controller
    {
        private IAntiforgery _antiForgery;
        public AntiForgeryController(IAntiforgery antiForgery)
        {
            _antiForgery = antiForgery;
        }

        [HttpGet]
        [Route("Generate")]
        [IgnoreAntiforgeryToken]
        public IActionResult GenerateAntiForgeryTokens()
        {
            return NoContent();
        }


        [HttpGet]
        [Route("GenerateByEndpoint")]
        [IgnoreAntiforgeryToken]
        public IActionResult GenerateAntiForgeryTokensEndpoint()
        {
            //var host = HttpContext.Request.Host.Value;
            //var cc = HttpContext;
            
            //var tokens = _antiForgery.GetAndStoreTokens(cc);
            //Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
            //    new CookieOptions() { 
            //        HttpOnly = false,
            //        Secure = true,
            //        IsEssential = true,
            //        SameSite = SameSiteMode.Strict
            //    });

            return NoContent();

        }
    }
}
