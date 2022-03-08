
using Common.OutputResult;
using System;
using System.Net;

namespace Common.Exceptions
{
    public class LogicException : AppException
    {
        public LogicException() 
            : base(ApiResultStatusCode.LogicError,HttpStatusCode.Conflict)
        {
        }

        public LogicException(string message) 
            : base(ApiResultStatusCode.LogicError, message,HttpStatusCode.Conflict)
        {
        }

        public LogicException(object additionalData) 
            : base(ApiResultStatusCode.LogicError,HttpStatusCode.Conflict, additionalData)
        {
        }

        public LogicException(string message, object additionalData) 
            : base(ApiResultStatusCode.LogicError, message,HttpStatusCode.Conflict, additionalData)
        {
        }

        public LogicException(string message, Exception exception)
            : base(ApiResultStatusCode.LogicError, message,HttpStatusCode.Conflict, exception)
        {
        }

        public LogicException(string message, Exception exception, object additionalData)
            : base(ApiResultStatusCode.LogicError, message,HttpStatusCode.Conflict, exception, additionalData)
        {
        }
    }
}
