using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using WebStoreWebApi.Exceptions;

namespace WebStoreWebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var customException = exception as CustomException;
            
            // Default exception details
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var message = "Internal Server Error";
            var description = "Internal Server Error";

            if (null != customException)
            {
                statusCode = customException.StatusCode;
                message = customException.Message;
                description = customException.Description;
            }

            return context.Response.WriteAsync(new ExceptionDetails()
            {
                StatusCode = statusCode,
                Message = message,
                Discription = description
            }.ToString());
        }
    }
}
