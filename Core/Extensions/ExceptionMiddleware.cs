using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
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
