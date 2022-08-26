using Core.CustomExceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.Extensions.Logging;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error has been thrown.");
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";

            switch (exception)
            {
                case ValidationException:
                    IEnumerable<ValidationFailure> errors;
                    errors = ((ValidationException)exception).Errors;

                    return httpContext.Response.WriteAsync(new ValidationErrorDetails
                    {
                        StatusCode = response.StatusCode = (int)HttpStatusCode.InternalServerError,
                        Errors = errors,
                        Message = exception.Message
                    }.ToString());
                case AccessDeniedException:
                    return httpContext.Response.WriteAsync(new ErrorDetails
                    {
                        StatusCode = response.StatusCode = (int)HttpStatusCode.Forbidden,
                        Message = exception.Message
                    }.ToString());

                case UnauthorizedException:
                    return httpContext.Response.WriteAsync(new ErrorDetails
                    {
                        StatusCode = response.StatusCode = (int)HttpStatusCode.Unauthorized,
                        Message = exception.Message
                    }.ToString());

                default:
                    return httpContext.Response.WriteAsync(new ErrorDetails
                    {
                        StatusCode = response.StatusCode = (int)HttpStatusCode.InternalServerError,
                        Message = exception.Message
                    }.ToString());
            }
        }
    }
}
