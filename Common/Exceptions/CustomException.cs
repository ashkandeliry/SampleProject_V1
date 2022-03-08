
using Common.Extensions;
using Common.OutputResult;
using System;

namespace Common.Exceptions
{
    public class CustomException : ITException
    {
        public int StatusCode { get; set; }

        public CustomException(ApiResultStatusCode statusCode) : base(statusCode.ToDisplay())
        {
            StatusCode = (int)statusCode;
        }

        public CustomException(string entityType) : base(entityType + ApiResultStatusCode.EntityNotFound.ToDisplay())
        {
            StatusCode = (int)ApiResultStatusCode.EntityNotFound;
        }
    }
}
