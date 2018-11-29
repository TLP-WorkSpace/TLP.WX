using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace WCP_demo
{
    public class GlobalAttribute : IExceptionFilter
    {

        readonly ILoggerFactory _loggerFactory;
        readonly IHostingEnvironment _env;

        public GlobalAttribute(ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            _loggerFactory = loggerFactory;
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            BaseResponse response = new BaseResponse
            {
                success = false,
                errorCode = -1,
                errorMessage = "未知错误"
            };

            if (context.Exception is GLException)
            {
                var ex = context.Exception as GLException;
                response.errorCode = ex.ErrorCode;
                response.errorMessage = ex.Message;
            }
           
            context.Result = new ApplicationErrorResult(response);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.ExceptionHandled = true;

            var logger = _loggerFactory.CreateLogger(context.Exception.TargetSite.ReflectedType);

            logger.LogError(new EventId(context.Exception.HResult),
            context.Exception,
            context.Exception.Message);
        }
    }
    public class ApplicationErrorResult : ObjectResult
    {
        public ApplicationErrorResult(object value) : base(value)
        {
            StatusCode = (int)HttpStatusCode.OK;
        }
    }
}

