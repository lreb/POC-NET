using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace FluenValidationTesting.CustomExceptionUtility
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (ex)
                {
                    case CustomException e:
                        response.StatusCode = ex.HttpWebStatusCode;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new CustomExceptionResponse 
                {
                    Message = ex?.Message, 
                    InternalCode = (int)ex.InternalCode,
                    Errors = ex.Errors
                });
                await response.WriteAsync(result);
            }
        }
    }
}
