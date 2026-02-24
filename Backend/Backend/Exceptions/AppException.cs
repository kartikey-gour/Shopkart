using Microsoft.AspNetCore.Http;
using System.Net;

namespace Backend.Exceptions
{
    public class AppException : Exception
    {
        public HttpStatusCode StatusCode { get; };      //Middleware decides HTTP response using this property
        public string ErrorCode { get; }  = string.Empty;

        protected AppException(HttpStatusCode statusCode, string errorCode, string message) : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }
    }
}