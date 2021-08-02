using AutoWrapper;
using System;

namespace ErrorHandler.ResponseWrapper
{
    public class MapResponseObject
    {
        /// <summary>
        /// API data result
        /// </summary>
        [AutoWrapperPropertyMap(Prop.Result)]
        public object Data { get; set; }


        ///// <summary>
        ///// API data result
        ///// </summary>
        //[AutoWrapperPropertyMap(Prop.IsError)]
        //public object IsError { get; set; }

        /// <summary>
        /// Response exception property 
        /// </summary>
        [AutoWrapperPropertyMap(Prop.ResponseException)]
        public Error Error { get; set; }

    }

    /// <summary>
    /// Error information
    /// </summary>
    public class Error
    {
        public string Message { get; set; }
        /// <summary>
        /// HTTP Code Error
        /// </summary>
        public string InternalCode { get; set; }
        /// <summary>
        /// Detailed error
        /// </summary>
        public InnerError InnerError { get; set; }

        /// <summary>
        /// Create error object
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <param name="inner"></param>
        public Error(string message, string code, InnerError inner)
        {
            this.Message = message;
            this.InternalCode = code;
            this.InnerError = inner;
        }

    }

    /// <summary>
    /// Detailed error
    /// </summary>
    public class InnerError
    {
        /// <summary>
        /// Request identifier
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// Exception date time
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Create inner error object
        /// </summary>
        /// <param name="reqId">string identifier for requests</param>
        /// <param name="reqDate">current exception date time</param>
        public InnerError(string reqId, string reqDate)
        {
            this.RequestId = reqId;
            this.Date = reqDate;
        }
    }

    #region Success Responses

    public class ApiServiceResponse
    {
        /// <summary>
        /// success internal code
        /// </summary>
        public string InternalCode { get; set; }
        /// <summary>
        /// possible message
        /// </summary>
        public string Message { get; set; }
        public object Payload { get; set; }
        /// <summary>
        /// Reply date time
        /// </summary>
        public DateTime SentDate { get; set; }
        /// <summary>
        /// Pagination reference
        /// </summary>
        public Pagination Pagination { get; set; }

        public ApiServiceResponse(DateTime sentDate, string statusCode, object payload = null, string message = "", Pagination pagination = null)
        {
            this.InternalCode = statusCode;
            this.Message = message == string.Empty ? "Success" : message;
            this.Payload = payload;
            this.SentDate = sentDate;
            this.Pagination = pagination;
        }

        /// <summary>
        /// Generate response
        /// </summary>
        /// <param name="sentDate">current date time</param>
        /// <param name="statusCode">Internal code</param>
        /// <param name="payload">API response payload</param>
        /// <param name="pagination">pagination information <seealso cref="Pagination"/></param>
        public ApiServiceResponse(DateTime sentDate, string statusCode, object payload = null, Pagination pagination = null)
        {
            this.InternalCode = statusCode;
            this.Message = "Success";
            this.Payload = payload;
            this.SentDate = sentDate;
            this.Pagination = pagination;
        }

        public ApiServiceResponse(object payload, string statusCode)
        {
            this.InternalCode = statusCode;
            this.Payload = payload;
        }

    }

    /// <summary>
    /// PAgination data
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// Total record for the query criteria
        /// </summary>
        public int TotalRecords { get; set; }
        /// <summary>
        /// Total of rows per page
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Number of the current page
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Total amount of pages
        /// </summary>
        public int TotalPages { get; set; }
    }

    #endregion
}
