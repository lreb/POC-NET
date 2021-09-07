using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

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

            //var tokens = _antiForgery.GetAndStoreTokens(HttpContext);
            //Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, new CookieOptions
            //{
            //    HttpOnly = false,
            //    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax
            //    //Expires = DateTime.UtcNow.AddMinutes(3),
            //    //IsEssential = true,
            //    //SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
            //    //Path = "/",
            //    //Domain = null, // "localhost",


            //    //Secure = false
            //});



            //var response = new HttpResponseMessage();


            //Response.Cookies.Append("myfakecookie", "lreb");
            //return Ok(tokens);
            ///

            //var resp = new HttpResponseMessage();

            //var message = new HttpResponseMessage();
            //var headers = message.Headers;
            ////headers.Add("XSRF-TOKEN-Request", $"{tokens.RequestToken}");
            ////headers.Add("XSRF-TOKEN-Cookie", $"{tokens.CookieToken}");

            ////var cookie = new Microsoft.Net.Http.Headers.CookieHeaderValue("username", "Sourav Kayal");
            ////cookie.Expires = System.DateTimeOffset.Now.AddDays(1);
            ////cookie.Domain = Request.HttpContext.Request.Host;
            ////cookie.Path = "/";
            ////resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            //return message;

        }
    }
}
