using System.Collections.Generic;

namespace FluenValidationTesting.CustomExceptionUtility
{
    public class CustomExceptionResponse
    {
        public int InternalCode { get; set; }
        public string Message { get; set; }
        public List<ValidationMessagesResponse> Errors { get; set; }
    }

    public class ValidationMessagesResponse
    {
        public string Field { get; set; }
        public string ErrorMessage { get; set; }
    }
}
