using Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Results;

namespace Common.OutputResult
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsSuccess { get; set; }

        public bool IsCached { get; set; }
        // public bool 

        /// <summary>
        /// 
        /// </summary>
        public ApiResultStatusCode StatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        // [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="isCached"></param>
        public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, bool isCached = false, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
            IsCached = isCached;

        }

        #region Implicit Operators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator ApiResult(System.Web.Http.Results.OkResult result)
        {
            return new ApiResult(true, ApiResultStatusCode.Success);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator ApiResult(System.Web.Http.Results.BadRequestResult result)
        {
            return new ApiResult(false, ApiResultStatusCode.BadRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator ApiResult(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }

            return new ApiResult(false, ApiResultStatusCode.BadRequest, message: message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator ApiResult(ContentResult result)
        {
            return new ApiResult(true, ApiResultStatusCode.Success, message: result.Content);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator ApiResult(System.Web.Http.Results.NotFoundResult result)
        {
            return new ApiResult(false, ApiResultStatusCode.NotFound);
        }

        #endregion
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class ApiResult<TData> : ApiResult
        where TData : class
    {
        /// <summary>
        /// 
        /// </summary>
        // [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TData Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? TotalCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="isCached"></param>
        public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, TData data, bool isCached = false,
            string message = null)
            : base(isSuccess, statusCode, isCached, message)
        {
            Data = data;
            // if (Data != null)
            // {
            //     
            // }
            // bool isIList = typeof(System.Collections.IList).IsAssignableFrom(Data.GetType());
            // if (isIList)
            // {
            //     TotalCount = (Data as IList)?.Count;
            //     
            // }
        }

        #region Implicit Operators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static implicit operator ApiResult<TData>(TData data)
        {
            return new ApiResult<TData>(true, ApiResultStatusCode.Success, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator ApiResult<TData>(System.Web.Http.Results.OkResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatusCode.Success, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator ApiResult<TData>(OkObjectResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatusCode.Success, (TData)result.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator ApiResult<TData>(System.Web.Http.Results.BadRequestResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatusCode.BadRequest, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator ApiResult<TData>(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }

            return new ApiResult<TData>(false, ApiResultStatusCode.BadRequest, null, message: message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator ApiResult<TData>(ContentResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatusCode.Success, null, message: result.Content);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator ApiResult<TData>(System.Web.Http.Results.NotFoundResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatusCode.NotFound, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator ApiResult<TData>(NotFoundObjectResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatusCode.NotFound, (TData)result.Value);
        }

        #endregion
    }
}
