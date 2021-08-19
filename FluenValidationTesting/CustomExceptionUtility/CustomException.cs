using System;
using System.Collections.Generic;
using System.Globalization;

namespace FluenValidationTesting.CustomExceptionUtility
{
    public class CustomException : Exception
    {
        public CustomInternalErrors InternalCode { get; set; }
        public int HttpWebStatusCode { get; set; }
        public List<ValidationMessagesResponse> Errors { get; set; }

        public CustomException(string message, CustomInternalErrors internalCode, int httpCode)
            : base(string.Format(CultureInfo.CurrentCulture, message))
        {
            InternalCode = internalCode;
            HttpWebStatusCode = httpCode;
        }

        public CustomException(string message, CustomInternalErrors internalCode, int httpCode, List<ValidationMessagesResponse> errors)
            : base(string.Format(CultureInfo.CurrentCulture, message))
        {
            InternalCode = internalCode;
            HttpWebStatusCode = httpCode;
            Errors = errors;
        }

        //public CustomException() : base()
        //{
        //}

        //public CustomException(string message) : base(message)
        //{
        //}

        //public CustomException(string message, Exception innerException) : base(message, innerException)
        //{
        //}
    }
}
